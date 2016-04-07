using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Data;

namespace Northwind1.Models
{
    public class OdbcReaderFactory : IReaderFactory
    {
        //Accepts an SQL string, executes it through the DB connection and returns a dataset

        public IDataReader GetReader(string sql)
        {
            OdbcConnection aConnection = new OdbcConnection(); ;

            // Initiate database connection
            aConnection.ConnectionString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=C:\Users\Mike\Documents\Northwind.mdb;";
            aConnection.Open();

            // Create command object
            OdbcCommand aCommand = aConnection.CreateCommand();

            // Attach query to command object
            aCommand.CommandText = sql;

            // Execute SQL command on database
            IDataReader aReader = aCommand.ExecuteReader();

            return aReader;
        }
    }
}