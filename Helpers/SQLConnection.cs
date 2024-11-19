using MySql.Data.MySqlClient;

namespace StayWise.Helpers
{
    public abstract class SQLConnection
    {
        private readonly string _connectionString;

        public SQLConnection()
        {
            _connectionString = "Server=localhost;Port=3306;Database=StayWiseLoginDb;User=root;Password=admin;";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}