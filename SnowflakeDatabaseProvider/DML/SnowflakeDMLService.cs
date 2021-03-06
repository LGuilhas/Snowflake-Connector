/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace SnowflakeDatabaseProvider.DML {

    /// <summary>
    /// Defines a contract for generating SQL fragments to interact with a database.
    /// </summary>
    public class SnowflakeDMLService : BaseDMLService {

        private readonly IDMLQueries queries;
        private readonly IDMLIdentifiers identifiers;
        private readonly IDMLOperators operators;
        private readonly IDMLFunctions functions;
        private readonly IDMLAggregateFunctions aggregateFunctions;
        private readonly IDMLDefaultValues defaultValues;
        private readonly IDMLSyntaxHighlightDefinitions syntaxHighlightDefinitions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DMLService"/> class.
        /// </summary>
        /// <param name="databaseServices">The database services.</param>
        public SnowflakeDMLService(IDatabaseServices databaseServices)
            : base(databaseServices)
        {
            queries = new SnowflakeDMLQueries(this);
            identifiers = new SnowflakeDMLIdentifiers(this);
            operators = new SnowflakeDMLOperators(this);
            functions = new SnowflakeDMLFunctions(this);
            aggregateFunctions = new SnowflakeDMLAggregateFunctions(this);
            defaultValues = new SnowflakeDMLDefaultValues(this);
            syntaxHighlightDefinitions = new SnowflakeDMLSyntaxHighlightDefinitions(this);
        }

        /// <summary>
        /// Gets an object that generates the SQL fragments required to perform entity actions.
        /// </summary>
        /// <param name="tableSourceInfo">Information about the entity's underlying table source</param>
        /// <returns></returns>
        public override IDMLEntityActions GetEntityActions(ITableSourceInfo tableSourceInfo){
            return new SnowflakeDMLEntityActions(this, tableSourceInfo);
        }

        /// <summary>
        /// Gets an object that generates the SQL fragments required to perform specific queries (e.g. count query).
        /// </summary>
        public override IDMLQueries Queries { get { return queries; } }

        /// <summary>
        /// Gets an object that generates and manipulates SQL identifiers.
        /// </summary>
        public override IDMLIdentifiers Identifiers { get { return identifiers; } }

        /// <summary>
        /// Gets an object that generates the SQL operators required to execute simple queries.
        /// </summary>
        public override IDMLOperators Operators { get { return operators; } }

        /// <summary>
        /// Gets an object that generates the SQL functions required to execute simple queries
        /// </summary>
        public override IDMLFunctions Functions { get { return functions; } }

        /// <summary>
        /// Gets an object that generates the SQL aggregate functions required to execute simple queries
        /// </summary>
        public override IDMLAggregateFunctions AggregateFunctions { get { return aggregateFunctions; } }

        /// <summary>
        /// Gets an object that generates the SQL default values for each database type.
        /// </summary>
        public override IDMLDefaultValues DefaultValues { get { return defaultValues; } }

        /// <summary>
        /// Gets an object that defines a set of fragments (e.g. keywords, operators) of the database-specific dialect 
        /// that can be used to provide syntax highlighting in SQL statements
        /// </summary>
        public override IDMLSyntaxHighlightDefinitions SyntaxHighlightDefinitions
        {
            get { return syntaxHighlightDefinitions; }
        }
    }
}
