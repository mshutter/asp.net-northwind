using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace Northwind1.Models
{
    public class OleDBReaderFactory : IReaderFactory
    {
        //Accepts an SQL string, executes it through the DB connection and returns a dataset

        public IDataReader GetReader (string sql)
        {
            // Database connection object
            OleDbConnection aConnection = new OleDbConnection();

            // Initiate database connection
            aConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Mike\Documents\Northwind.mdb;";
            aConnection.Open();

            // Create command object
            OleDbCommand aCommand = aConnection.CreateCommand();

            // Attach query to command object
            aCommand.CommandText = sql;

            // Execute SQL command on database
            IDataReader aReader = aCommand.ExecuteReader();

            return aReader;
        }
    }
}