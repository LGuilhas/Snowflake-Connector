/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;

namespace SnowflakeDatabaseProvider.Configuration
{

    /// <summary> 
    /// The configuration object used to create services and open connections to the database. 
    /// <remarks>We have other configuration interfaces like <see cref="IIntegrationDatabaseConfiguration" /> 
    /// that are used to specify the UI of a configuration screen.</remarks> 
    /// </summary>
    public class SnowflakeRuntimeDatabaseConfiguration : IRuntimeDatabaseConfiguration
    {
        /// <summary>
        /// Gets the database provider. It provides information about the database,
        /// and access to its services.
        /// </summary>
        public IDatabaseProvider DatabaseProvider
        {
            get { return SnowflakeDatabaseProvider.Instance; }
        }

        /// <summary>
        /// Gets the connection string that allows connecting to a database.
        /// </summary>
        [ConfigurationParameter(Encrypt = true)]
        public string ConnectionString { get; set; }

        [ConfigurationParameter]
        public string Account { get; set; }

        [ConfigurationParameter]
        public string Server { get; set; }

        [ConfigurationParameter]
        public string Warehouse { get; set; }

        /// <summary>
        /// The user that this configuration uses to connect to the database.
        /// </summary>
        [ConfigurationParameter]
        public string Username { get; set; }

        [ConfigurationParameter]
        public string Role { get; set; }

        /// <summary>
        /// Gets the database identifier to be used in the configuration.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DatabaseIdentifier
        {
            get { return Account + "_" + Warehouse; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (SnowflakeRuntimeDatabaseConfiguration)obj;

            return
                DatabaseProvider == other.DatabaseProvider
                && Username == other.Username
                && ConnectionString == other.ConnectionString
                && Account == other.Account
                && Server == other.Server
                && Warehouse == other.Warehouse
                && Username == other.Username
                && Role == other.Role;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            
            if (ConnectionString != null)
            {
                hash = hash * 31 + ConnectionString.GetHashCode();
            }
            if (Account != null)
            {
                hash = hash * 31 + Account.GetHashCode();
            }
            if (Server != null)
            {
                hash = hash * 31 + Server.GetHashCode();
            }
            if (Warehouse != null)
            {
                hash = hash * 31 + Warehouse.GetHashCode();
            }
            if (Username != null)
            {
                hash = hash * 31 + Username.GetHashCode();
            }
            if (Role != null)
            {
                hash = hash * 31 + Role.GetHashCode();
            }
            return hash;
        }
    }
}
