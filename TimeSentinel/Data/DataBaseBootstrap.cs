using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TimeSentinel.Data
{
    internal class DataBaseBootstrap
    {
        private const string ConnectionString = "Data Source=Timer.db";

        public void Setup()
        {
            using var connection = new SqliteConnection(ConnectionString);
            string sql = @"CREATE TABLE IF NOT EXISTS ProcessTable(
                          processId INTEGER PRIMARY KEY AUTOINCREMENT,
                          processName TEXT,
                          processTotalTime INTEGER);";
            connection.Execute(sql);
        }
    }
}
