/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace SnowflakeDatabaseProvider.DML {

    /// <summary>
    /// Class to generate the DML operators required by the applications to perform simple queries.
    /// </summary>
    public class SnowflakeDMLOperators : BaseDMLOperators
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DMLOperators"/> class.
        /// </summary>
        /// <param name="dmlService">The DML service.</param>
        internal SnowflakeDMLOperators(IDMLService dmlService) : base(dmlService) { }

        public override string Concatenate(string v1, string v2)
        {
            return "CONCAT(" + v1 + "," + v2 + ")";
        }
    }
}
