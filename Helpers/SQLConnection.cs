using Microsoft.Data.SqlClient;

namespace StayWise.Helpers
{
    public abstract class SQLConnection
    {
        private readonly string _connectionString;
        public SQLConnection()
        {
            _connectionString = "Server=(local); Database=StayWiseLoginDb; Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
