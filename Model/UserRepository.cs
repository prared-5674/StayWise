using MySql.Data.MySqlClient;
using StayWise.Helpers;
using StayWise.Interfaces;
using System.Net;

namespace StayWise.Model
{
    public class UserRepository : SQLConnection, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from User where username=@username and password=@password";
                command.Parameters.AddWithValue("@username", credential.UserName);
                command.Parameters.AddWithValue("@password", credential.Password);
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from User where username=@username";
                command.Parameters.AddWithValue("@username", username ?? throw new ArgumentNullException(nameof(username)));

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0]?.ToString() ?? string.Empty,
                            Username = reader[1]?.ToString() ?? string.Empty,
                            Password = string.Empty,
                            Name = reader[3]?.ToString() ?? string.Empty,
                            LastName = reader[4]?.ToString() ?? string.Empty,
                            Email = reader[5]?.ToString() ?? string.Empty,
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}