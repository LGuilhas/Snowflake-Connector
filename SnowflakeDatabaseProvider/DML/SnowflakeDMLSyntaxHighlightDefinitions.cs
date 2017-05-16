using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace SnowflakeDatabaseProvider.DML {

    class SnowflakeDMLSyntaxHighlightDefinitions : GenericDMLSyntaxHighlightDefinitions
    {

        public SnowflakeDMLSyntaxHighlightDefinitions(SnowflakeDMLService dmlService) : base(dmlService) { }


        public override IEnumerable<string> Keywords
        {
            get
            {
                return new[] {
                    "ACCESSIBLE", "ADD", "ALL", "ALTER", "ANALYZE", "AS", "ASC", "ASENSITIVE", "BEFORE",
                    "BOTH", "BY", "CALL", "CASCADE", "CASE", "CHANGE", "CHARACTER", "CHECK", "COLLATE", "COLUMN",
                    "CONDITION", "CONSTRAINT", "CONTINUE", "CREATE", "CROSS",
                    "CURSOR", "DATABASES", "DAY_HOUR", "DAY_MICROSECOND", "DAY_MINUTE", "DAY_SECOND", "DEC",
                    "DECLARE", "DEFAULT", "DELAYED", "DELETE", "DESC", "DESCRIBE", "DETERMINISTIC", "DISTINCT", "DISTINCTROW",
                    "DROP", "DUAL", "EACH", "ELSE", "ELSEIF", "ENCLOSED", "ESCAPED", "EXISTS", "EXIT", "EXPLAIN", "FALSE",
                    "FETCH", "FLOAT4", "FLOAT8", "FOR", "FORCE", "FOREIGN", "FROM", "FULLTEXT", "GRANT", "GROUP", "HAVING",
                    "HIGH_PRIORITY", "HOUR_MICROSECOND", "HOUR_MINUTE", "HOUR_SECOND", "IGNORE", "INDEX", "INFILE", "INNER",
                    "INOUT", "INSENSITIVE", "INSERT", "INT1", "INT2", "INT3", "INT4", "INT8", "INTO",
                    "IO_AFTER_GTIDS", "IO_BEFORE_GTIDS", "IS", "ITERATE", "JOIN", "KEY", "KEYS", "KILL", "LEADING", "LEAVE",
                    "LIMIT", "LINEAR", "LINES", "LOAD", "LOCK", "LONG", "LOOP",
                    "LOW_PRIORITY", "MASTER_BIND", "MASTER_SSL_VERIFY_SERVER_CERT", "MAXVALUE",
                    "MIDDLEINT", "MINUTE_MICROSECOND", "MINUTE_SECOND", "MODIFIES", "NATURAL",
                    "NO_WRITE_TO_BINLOG", "NULL", "ON", "OPTIMIZE", "OPTION", "OPTIONALLY", "ORDER", "OUT", "OUTER",
                    "OUTFILE", "PARTITION", "PRECISION", "PRIMARY", "PROCEDURE", "PURGE", "RANGE", "READ", "READS", "READ_WRITE",
                    "REFERENCES", "RELEASE", "RENAME", "REQUIRE", "RESIGNAL", "RESTRICT", "RETURN", "REVOKE",
                    "SCHEMAS", "SECOND_MICROSECOND", "SELECT", "SENSITIVE", "SEPARATOR", "SHOW", "SIGNAL",
                    "SPATIAL", "SPECIFIC", "SQL", "SQLEXCEPTION", "SQLSTATE", "SQLWARNING", "SQL_BIG_RESULT",
                    "SQL_CALC_FOUND_ROWS", "SQL_SMALL_RESULT", "SSL", "STARTING", "STRAIGHT_JOIN", "TABLE", "TERMINATED", "THEN",
                    "TO", "TRAILING", "TRIGGER", "TRUE", "UNDO", "UNION", "UNIQUE", "UNLOCK", "UNSIGNED", "UPDATE",
                    "USAGE", "USE", "USING", "VALUES", "VARCHARACTER",
                    "VARYING", "WHEN", "WHERE", "WHILE", "WITH", "WRITE", "YEAR_MONTH", "ZEROFILL", "GET", "IO_AFTER_GTIDS",
                    "IO_BEFORE_GTIDS", "MASTER_BIND", "ONE_SHOT", "PARTITION", "SQL_AFTER_GTIDS", "SQL_BEFORE_GTIDS"
                };
            }
        }

        /// <summary>
        /// Based on https://docs.snowflake.net/manuals/sql-reference/functions-all.html
        /// </summary>
        public override IEnumerable<string> Functions
        {
            get
            {
                return new[] {
                    "ABS","ACOS","ACOSH","ADD_MONTHS","ANY_VALUE","APPROX_COUNT_DISTINCT","ARRAY_AGG","ARRAY_APPEND",
                    "ARRAY_CAT","ARRAY_COMPACT","ARRAY_CONSTRUCT","ARRAY_CONSTRUCT_COMPACT","ARRAY_INSERT","ARRAY_PREPEND",
                    "ARRAY_SIZE","ARRAY_SLICE","ARRAY_TO_STRING","AS_ARRAY","AS_BINARY","AS_CHAR","AS_VARCHAR","AS_DATE",
                    "AS_DECIMAL", "AS_NUMBER","AS_DOUBLE", "AS_REAL","AS_INTEGER","AS_OBJECT","AS_TIME","AS_TIMESTAMP_*","ASCII","ASIN",
                    "ASINH","ATAN","ATAN2","ATANH","AVG","BASE64_DECODE_BINARY","BASE64_DECODE_STRING","BASE64_ENCODE","BETWEEN",
                    "BIT_LENGTH","BITAND","BITAND_AGG","BITNOT","BITOR","BITOR_AGG","BITSHIFTLEFT","BITSHIFTRIGHT","BITXOR","BITXOR_AGG",
                    "CASE","CAST","CBRT","CEIL","CHARINDEX","CHECK_JSON","CHECK_XML","CHR", "CHAR","COALESCE","CONCAT",
                    "CONTAINS","CONVERT_TIMEZONE","CORR","COS","COSH","COT","COUNT","COVAR_POP","COVAR_SAMP","CUME_DIST","CURRENT_CLIENT",
                    "CURRENT_DATABASE","CURRENT_DATE","CURRENT_ROLE","CURRENT_SCHEMA","CURRENT_SCHEMAS","CURRENT_SESSION",
                    "CURRENT_STATEMENT","CURRENT_TIME","CURRENT_TIMESTAMP","CURRENT_TRANSACTION","CURRENT_USER","CURRENT_VERSION",
                    "CURRENT_WAREHOUSE","DATABASE_STORAGE_USAGE_HISTORY","DATE_FROM_PARTS","DATE_PART","DATE_TRUNC","DATEADD","DATEDIFF",
                    "DAYNAME","DECODE","DEGREES","DENSE_RANK","EDITDISTANCE","ENDSWITH","EQUAL_NULL","EXP","EXTRACT","FIRST_VALUE",
                    "FLATTEN","FLOOR","GENERATOR","GET","GET_DDL","GET_PATH","GREATEST","GROUPING","GROUPING_ID","HASH","HASH_AGG",
                    "HAVERSINE","HEX_DECODE_BINARY","HEX_DECODE_STRING","HEX_ENCODE","HLL","HLL_ACCUMULATE","HLL_COMBINE","HLL_ESTIMATE",
                    "HLL_EXPORT","HLL_IMPORT","IFF","IFNULL","ILIKE","IN", "NOT IN","INSERT",
                    "IS NULL", "IS NOT NULL","IS_ARRAY","IS_BINARY","IS_CHAR", "IS_VARCHAR","IS_DATE","IS_DATE_VALUE","IS_DECIMAL",
                    "IS_DOUBLE","IS_REAL","IS_INTEGER","IS_NULL_VALUE","IS_OBJECT","IS_TIME","IS_TIMESTAMP_*","LAG","LAST_DAY",
                    "LAST_QUERY_ID","LAST_TRANSACTION","LAST_VALUE","LEAD","LEAST","LEFT","LENGTH","LIKE","LISTAGG","LN",
                    "LOCALTIME","LOCALTIMESTAMP","LOG","LOWER","LPAD","LTRIM","MD5","MD5_HEX","MD5_BINARY","MD5_NUMBER","MEDIAN",
                    "MIN", "MAX","MOD","MONTHNAME","NORMAL","NTILE","NULLIF","NVL","NVL2","OBJECT_AGG","OBJECT_CONSTRUCT",
                    "OBJECT_DELETE","OBJECT_INSERT","OCTET_LENGTH","PARSE_JSON","PARSE_URL","PARSE_XML","PERCENT_RANK",
                    "PERCENTILE_CONT","PERCENTILE_DISC","PI","POSITION","POW, POWER","QUERY_HISTORY", "QUERY_HISTORY_BY_*",
                    "RADIANS","RANDOM","RANDSTR","RANK","REGEXP","REGEXP_COUNT","REGEXP_INSTR","REGEXP_LIKE","REGEXP_REPLACE",
                    "REGEXP_SUBSTR","REGR_AVGX","REGR_AVGY","REGR_COUNT","REGR_INTERCEPT","REGR_R2","REGR_SLOPE","REGR_SXX",
                    "REGR_SXY","REGR_SYY","REGR_VALX","REGR_VALY","REPEAT","REPLACE","RESULT_SCAN","REVERSE","RIGHT","RLIKE",
                    "ROUND","ROW_NUMBER","RPAD","RTRIM","RTRIMMED_LENGTH","SEQ1", "SEQ2", "SEQ4", "SEQ8","SHA1", "SHA1_HEX","SHA1_BINARY",
                    "SHA2", "SHA2_HEX","SHA2_BINARY","SIGN","SIN","SINH","SPACE","SPLIT","SPLIT_PART","SQRT","SQUARE",
                    "STAGE_STORAGE_USAGE_HISTORY","STARTSWITH","STDDEV","STDDEV_POP","STDDEV_SAMP","STRIP_NULL_VALUE",
                    "SUBSTR", "SUBSTRING","SUM","SYSTEM$ABORT_SESSION","SYSTEM$ABORT_TRANSACTION","SYSTEM$CANCEL_ALL_QUERIES",
                    "SYSTEM$CANCEL_QUERY","SYSTEM$CLUSTERING_RATIO","SYSTEM$TYPEOF","SYSTEM$WAIT","TAN","TANH","TIME_FROM_PARTS",
                    "TIMEADD","TIMEDIFF","TIMESTAMP_FROM_PARTS","TIMESTAMPADD","TIMESTAMPDIFF","TO_ARRAY","TO_BINARY","TO_BOOLEAN",
                    "TO_CHAR","TO_VARCHAR","TO_DATE","TO_DECIMAL","TO_NUMBER","TO_NUMERIC","TO_DOUBLE","TO_JSON","TO_OBJECT","TO_TIME",
                    "TO_TIMESTAMP", "TO_TIMESTAMP_*","TO_VARIANT","TO_XML","TRANSLATE","TRIM","TRUNC", "TRUNCATE",
                    "TRY_BASE64_DECODE_BINARY","TRY_BASE64_DECODE_STRING","TRY_CAST","TRY_HEX_DECODE_BINARY","TRY_HEX_DECODE_STRING",
                    "TRY_TO_BINARY","TRY_TO_BOOLEAN","TRY_TO_DATE","TRY_TO_DECIMAL, TRY_TO_NUMBER, TRY_TO_NUMERIC","TRY_TO_DOUBLE",
                    "TRY_TO_TIME","TRY_TO_TIMESTAMP / TRY_TO_TIMESTAMP_*","TYPEOF","UNIFORM","UPPER","VALIDATE","VAR_POP","VAR_SAMP",
                    "VARIANCE","VARIANCE_SAMP","VARIANCE_POP","WAREHOUSE_LOAD_HISTORY","WAREHOUSE_METERING_HISTORY","WIDTH_BUCKET",
                    "XMLGET","YEAR", "QUARTER", "MONTH","WEEK","DAY", "MINUTE","HOUR","SECOND","ZEROIFNULL","ZIPF"
                };
            }
        }

        /// <summary>
        /// Based on https://docs.snowflake.net/manuals/sql-reference/functions-operators.html
        /// </summary>
        public override IEnumerable<string> Operators
        {
            get
            {
                return new[] {
                // Arithmetic
                "+", "-", "*", "/", "%",
                // Bitwise
                "&", "|", "^", "<<", ">>", "~",
                // Comparison
                "=", ">", "<", ">=", "<=", "<>", "!=", "<=>", "BETWEEN", 
                // Assignment
                ":=",
                // Logical
                "AND", "&&", "LIKE", "NOT", "!", "OR", "||", "XOR"
            };
            }
        }

        /// <summary>
        /// Based on https://docs.snowflake.net/manuals/sql-reference/data-types.html
        /// </summary>
        public override IEnumerable<string> DataTypes
        {
            get
            {
                return new[] {
                    // Numeric data types
                    "NUMBER", "DECIMAL", "NUMERIC", "INT", "INTEGER", "SMALLINT" , "TINYINT" , "BYTEINT", "FLOAT" , "FLOAT4" , "FLOAT8", "DOUBLE" , "DOUBLE PRECISION" , "REAL",
                    // Text/Character and Binary Data Types
                    "VARCHAR", "CHAR" , "CHARACTER", "STRING" , "TEXT", "BINARY", "VARBINARY",
                    //Logical Data Types — Limited Availability
                    "BOOLEAN",
                    // Date and Time Data Types
                    "DATE", "TIME", "DATETIME", "TIMESTAMP", "TIMESTAMP_*",
                    // Semi-Structured Data Types
                    "VARIANT", "OBJECT", "ARRAY"                };
            }
        }
    }
}
