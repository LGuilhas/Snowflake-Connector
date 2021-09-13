using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using SnowflakeDatabaseProvider.Execution;

namespace System.Data
{
    static class IDbCommandExtensions
    {
        static readonly Regex paramPattern = new Regex(@"(\@\w+)", RegexOptions.Compiled);
        static readonly Regex insertPattern = new Regex(@"\w+\.\w+\.\w+\.(""\w+"")", RegexOptions.Compiled);

        //As we are relying on an ODBC driver and named parameters are not supported
        //we need to fix the command by 1st replacing the named parameters @xpto with ?
        //and setting the list of parameters with the proper order.

        //Update (27/08/2021): The OleDbDriver doesn't support named params as well so we keep this logic 
        public static IDbCommand FixOdbcParameters(this IDbCommand cmd, bool isForReader)
        {
            List<IDataParameter> newParams = new List<IDataParameter>();

            var parameterIndex = 0;
            cmd.CommandText = paramPattern.Replace(cmd.CommandText, delegate(Match m)
            {
                string paramName = m.Groups[1].Value;

                if (cmd.Parameters.Contains(paramName))
                {
                    IDataParameter currentParam = (IDataParameter)cmd.Parameters[paramName];

                    newParams.Insert(parameterIndex++, currentParam);
                    return "?";
                }
                else
                {
                    return paramName;
                }
            });

            //UPDATES and INSERTS are beign executed as readers when done from advanced queries therefore
            //we need to take that into consideration and replace the namespace on the parameters
            if (isForReader && !cmd.CommandText.ToUpper().StartsWith("SELECT"))
            {
                cmd.CommandText = insertPattern.Replace(cmd.CommandText, "$1");
                isForReader = false;
            }

            cmd.Parameters.Clear();
            int paramIdx = 1;
            foreach (IDataParameter newParam in newParams)
            {
                //booleans are forced as string for compatibility when updating
                if (!isForReader && newParam.DbType == DbType.Boolean)
                {
                    newParam.DbType = DbType.String;
                }

                ////If the same parameter is used multiple times in the same query it will cause a duplicate issue
                ////we fix the name by appending an incremental number
                string fixParamName = newParam.ParameterName + paramIdx;

                if (!newParam.ParameterName.Equals(fixParamName))
                {
                    IDataParameter fixedParameter = cmd.CreateParameter();

                    fixedParameter.DbType = newParam.DbType;
                    fixedParameter.Direction = newParam.Direction;
                    //The Snowflake OleDb driver does not support named params therefore 
                    //we pass the index as the name to use it instead as this is the equivalent to
                    //SnowflakeDbParameter(int ParameterIndex, SFDataType SFDataType)
                    fixedParameter.ParameterName = paramIdx.ToString();
                    fixedParameter.SourceColumn = newParam.SourceColumn;
                    fixedParameter.SourceVersion = newParam.SourceVersion;
                    fixedParameter.Value = newParam.Value;

                    cmd.Parameters.Add(fixedParameter);
                }
                else
                {
                    cmd.Parameters.Add(newParam);
                }

                paramIdx++;
            }

            return cmd;
        }
    }
}
