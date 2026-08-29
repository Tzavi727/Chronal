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
        private const string ConnectionString = "Data Source=TimerData.db";
        
        public void Setup()
        {
            SQLitePCL.Batteries.Init();
            using var connection = new SqliteConnection(ConnectionString);
            string sql = @"CREATE TABLE IF NOT EXISTS ProcessTable(
                          processId INTEGER PRIMARY KEY AUTOINCREMENT,
                          isActive INTEGER,
                          processName TEXT,
                          processTotalTime INTEGER);";
            connection.Execute(sql);
        }
    }
}
