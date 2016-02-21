using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace TelerikLibrary.DA
{
    public class SqLiteConnector
    {
        private SQLiteConnection _sqlConnection;
        private SQLiteCommand _sqlCommand;
        private SQLiteDataAdapter _adapter;
        private DataSet _dataSet = new DataSet();
        private DataTable _dataTable = new DataTable();

        public string ConnectionString = @"Data Source=|DataDirectory|\books.db;Version=3;New=false;Compress=true;";

        public SQLiteConnection Connect()
        {
            return _sqlConnection = new SQLiteConnection(ConnectionString);
        }

        public void Disconnect(SQLiteConnection connection)
        {
            connection.Close();
        }

        public void ExecuteQuery(string sqlQuery)
        {
            _sqlConnection = Connect();
            _sqlConnection.Open();

            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandText = sqlQuery;
            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public DataTable LoadData(string sqlQuery)
        {
            _sqlConnection = Connect();
            _sqlConnection.Open();

            _sqlCommand = _sqlConnection.CreateCommand();

            _adapter = new SQLiteDataAdapter(sqlQuery, _sqlConnection);
            _dataSet.Reset();
            _adapter.Fill(_dataSet);
            _dataTable = _dataSet.Tables[0];
            _sqlConnection.Close();

            return _dataTable;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}