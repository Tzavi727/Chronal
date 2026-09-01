using Dapper;
using Microsoft.Data.Sqlite;

namespace Chronal.Data
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
                          isCounterActive INTEGER DEFAULT 0,
                          processName TEXT,
                          processTotalTime INTEGER,
                          lastRunTime TEXT);";
            connection.Execute(sql);
        }
    }
}
