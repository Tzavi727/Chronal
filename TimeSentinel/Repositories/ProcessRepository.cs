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

        public void AddProcess(TrackedProcess process)
        {
            using var connection = new SqliteConnection(_connectionString);

            string sql = @"INSERT INTO ProcessTable (processName, processTotalTime)
                           VALUES (@ProcessName, @ProcessTotalTime)";
            connection.Execute(sql, process);
        }
        public void RemoveProcess(int processId)
        {
            using var connection = new SqliteConnection(_connectionString);
            string sql = "DELETE FROM ProcessTable WHERE processId = @ProcessId";
            connection.Execute(sql, new { ProcessId = processId });
        }
        public IEnumerable<TrackedProcess> GetAll()
        {
            using var connection = new SqliteConnection(_connectionString);
            var sql = "SELECT * FROM ProcessTable";
            return connection.Query<TrackedProcess>(sql);
        }
        public void UpdateProcessTime(string processName, int newTotalTime, bool isActive)
        {
            using var connection = new SqliteConnection(_connectionString);
            string sql = @"UPDATE ProcessTable SET processTotalTime = @newTotalTime, isCounterActive = @isActive WHERE processName = @processName";

            connection.Execute(sql, new { newTotalTime, isActive, processName });
        }
        public TrackedProcess? GetProcessByName(string name)
        {
            using var connection = new SqliteConnection(_connectionString);

            return connection.QueryFirstOrDefault<TrackedProcess>(
                "SELECT * FROM ProcessTable WHERE processName = @Name", new { Name = name });
        }
    }
}
