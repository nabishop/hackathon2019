using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace RhopikApi.Models
{
    public class UserItemContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DbSet<UserItem> UserItems { get; set; }

        public UserItemContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<UserItem> GetUsers()
        {
            List<UserItem> list = new List<UserItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from users", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserItem()
                        {
                            Name = reader["name"].ToString(),
                            Password = reader["password"].ToString(),
                            Id = Convert.ToInt32(reader["user_id"])
                        });
                    }
                }
            }
            return list;

        }
    }
}
