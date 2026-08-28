using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSentinel.Data;
using TimeSentinel.Interfaces;
using TimeSentinel.Models;

namespace TimeSentinel.Repositories
{
    internal class ProcessRepository : IProcessRepository
    {
        private readonly string _connectionString;
        public ProcessRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddProcess(ProcessRecord process)
        {
            using var connection = new SqliteConnection(_connectionString);

            string sql = @"INSERT INTO ProcessTable (processName, processTotalTime)
                           VALUES (@ProcessName, @ProcessTotalTime)";
            connection.Execute(sql, process);
        }
        public void RemoveProcess(int ProcessId)
        {
            using var connection = new SqliteConnection(_connectionString);
            string sql = "DELETE FROM ProcessTable WHERE processId = @ProcessId";
            connection.Execute(sql, new { processId = ProcessId});
        }
        public void UpdateProcessTime(string processName, int newTotalTime)
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "UPDATE ProcessTable SET processTotalTime = @NewTime WHERE processName = @ProcessName";
            connection.Execute(sql, new { NewTime = newTotalTime, Name = processName });
        }
        public ProcessRecord GetProcessByName(string name)
        {
            using var connection = new SqliteConnection(_connectionString);

#pragma warning disable CS8603 // Possible null reference return.
            return connection.QueryFirstOrDefault<ProcessRecord>(
                "SELECT * FROM ProcessTable WHERE processName = @Name", new { Name = name });
#pragma warning restore CS8603 // Possible null reference return.
        } 
    }
}
