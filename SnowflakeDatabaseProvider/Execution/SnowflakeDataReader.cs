using System;
using System.Collections;
using System.Data;
using System.Data.Common;

using Snowflake.Data.Client;


namespace SnowflakeDatabaseProvider.Execution
{
    /// <summary>
    /// This class extends the DbDataReader and uses an instance of an OdbcDataReader to do the job
    /// The reason behind this approach was because with this OdbcDriver DBType.Time is return as Timestamp
    /// which was causing a failure on the conversion on OutSystems.HubEdition.RuntimePlatform.DataReaderUtils.ReadDateTime
    /// Unable to cast object of type 'System.TimeSpan' to type 'System.IConvertible'.
    /// Only the indexers [] are customized.
    /// </summary>
    class SnowflakeDataReader : DbDataReader
    {
        private SnowflakeDbDataReader otherReader;

        public SnowflakeDataReader(SnowflakeDbDataReader otherReader)
        {
            this.otherReader = otherReader;
        }

        public override int Depth
        {
            get
            {
                return otherReader.Depth;
            }
        }

        public override int FieldCount
        {
            get
            {
                return otherReader.FieldCount;
            }
        }
        public override bool HasRows
        {
            get
            {
                return otherReader.HasRows;
            }
        }
        public override bool IsClosed
        {
            get
            {
                return otherReader.IsClosed;
            }
        }
        public override int RecordsAffected
        {
            get
            {
                return otherReader.RecordsAffected;
            }
        }

        public override object this[int i]
        {
            get
            {
                object obj = otherReader[i];

                if (obj is TimeSpan)
                {
                    TimeSpan ts = (TimeSpan)obj;
                    obj = new System.DateTime(1900, 1, 1, ts.Hours, ts.Minutes, ts.Seconds);
                }

                return obj;
            }
        }

        public override object this[string value]
        {
           get
            {
                object obj = otherReader[value];

                if (obj is TimeSpan)
                {
                    TimeSpan ts = (TimeSpan)obj;
                    obj = new System.DateTime(1900, 1, 1, ts.Hours, ts.Minutes, ts.Seconds);
                }

                return obj;
            }
        }

        public override void Close()
        {
            otherReader.Close();
        }

        protected override void Dispose(bool disposing)
        {
            otherReader.Dispose();
        }

        public override bool GetBoolean(int i)
        {
            return otherReader.GetBoolean(i);
        }

        public override byte GetByte(int i)
        {
            return otherReader.GetByte(i);
        }
        
        public override long GetBytes(int i, long dataIndex, byte[] buffer, int bufferIndex, int length)
        {
            return otherReader.GetBytes(i, dataIndex, buffer, bufferIndex, length);
        }

        public override char GetChar(int i)
        {
            return otherReader.GetChar(i);
        }

        public override long GetChars(int i, long dataIndex, char[] buffer, int bufferIndex, int length)
        {
            return otherReader.GetChars(i, dataIndex, buffer, bufferIndex, length);
        }

        public override string GetDataTypeName(int i)
        {
            return otherReader.GetDataTypeName(i);
        }

        public DateTime GetDate(int i)
        {
            return otherReader.GetDateTime(i);
        }

        public override DateTime GetDateTime(int i)
        {
            return otherReader.GetDateTime(i);
        }

        public override decimal GetDecimal(int i)
        {
            return otherReader.GetDecimal(i);
        }

        public override double GetDouble(int i)
        {
            return otherReader.GetDouble(i);
        }

        public override IEnumerator GetEnumerator()
        {
            return otherReader.GetEnumerator();
        }

        public override Type GetFieldType(int i)
        {
            return otherReader.GetFieldType(i);
        }

        public override float GetFloat(int i)
        {
            return otherReader.GetFloat(i);
        }

        public override Guid GetGuid(int i)
        {
            return otherReader.GetGuid(i);
        }

        public override short GetInt16(int i)
        {
            return otherReader.GetInt16(i);
        }

        public override int GetInt32(int i)
        {
            return otherReader.GetInt32(i);
        }

        public override long GetInt64(int i)
        {
            return otherReader.GetInt64(i);
        }

        public override string GetName(int i)
        {
            return otherReader.GetName(i);
        }

        public override int GetOrdinal(string value)
        {
            return otherReader.GetOrdinal(value);
        }

        public override DataTable GetSchemaTable()
        {
            return otherReader.GetSchemaTable();
        }

        public override string GetString(int i)
        {
            return otherReader.GetString(i);
        }

        public TimeSpan GetTime(int i)
        {
            return otherReader.GetTimeSpan(i);
        }

        public override object GetValue(int i)
        {
            return otherReader.GetValue(i);
        }

        public override int GetValues(object[] values)
        {
            return otherReader.GetValues(values);
        }

        public override bool IsDBNull(int i)
        {
            return otherReader.IsDBNull(i);
        }

        public override bool NextResult()
        {
            return otherReader.NextResult();
        }

        public override bool Read()
        {
            return otherReader.Read();
        }
    }
}
