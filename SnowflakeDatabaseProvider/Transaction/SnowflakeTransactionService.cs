/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Data;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using Snowflake.Data.Client;

namespace SnowflakeDatabaseProvider.Transaction
{

    /// <summary>
    /// Database service that handles connection and transaction management to a access a database.
    /// </summary>
    public class SnowflakeTransactionService : BaseTransactionService
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="databaseServices">The database services to be used by this service.</param>
        public SnowflakeTransactionService(IDatabaseServices databaseServices) : base(databaseServices) { }

        /// <summary>
        /// Gets the isolation level to be used in the transactions.
        /// </summary>
        protected override IsolationLevel IsolationLevel
        {
            //Snowflake OleDB drive does not support read uncommited
            get { return IsolationLevel.ReadCommitted; }
        }

        /// <summary>
        /// Gets the connection from driver.
        /// </summary>
        /// <returns></returns>
        protected override IDbConnection GetConnectionFromDriver()
        {
            /* Return here a connection created using the driver's API for create a new connection.
             * You should specify its connection string with the one defined in DatabaseServices.DatabaseConfiguration.ConnectionString */
            return new SnowflakeDbConnection()
            {
                ConnectionString = DatabaseServices.DatabaseConfiguration.ConnectionString
            };
        }

        /// <summary>
        /// Releases all connections in the pool.
        /// </summary>
        protected override void ReleaseAllPooledConnections()
        {
            //Didn't find a way to do this with the OleDb driver
        }

        /// <summary>
        /// Checks if a separate connection is needed to connect to another catalog.
        /// </summary>
        public override bool NeedsSeparateAdminConnection
        {
            get { return false; }
        }
    }
}
