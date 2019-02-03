using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace RhopikApi.Models
{
    public class PlaylistItemContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DbSet<UserItem> UserItems { get; set; }

        public PlaylistItemContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<PlaylistItem> GetPlaylists()
        {
            List<PlaylistItem> list = new List<PlaylistItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from playlists", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PlaylistItem()
                        {
                            Name = reader["name"].ToString(),
                            Vibe = reader["vibe"].ToString(),
                            DateAdded = reader["date_added"].ToString(),
                            Song_ID = Convert.ToInt32(reader["song_id"]),
                            User_ID = Convert.ToInt32(reader["user_id"])
                        });
                    }
                }
            }
            return list;
        }

        public void PutPlaylistName(int userId, string oldName, string newName)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE playlists SET name=" + newName
                    + " WHERE name=" + oldName + " AND user_id=" + userId, conn);

                System.Console.WriteLine(cmd.ExecuteNonQuery());
                conn.Close();
            }
        }

        public void DeletePlaylist(string name, int userId)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM playlists where name=" 
                    + name + " AND user_id=" + userId, conn);

                System.Console.WriteLine(cmd.ExecuteNonQuery());
                conn.Close();
            }
        }

        public List<PlaylistItem> GetPlaylistsWithUserID(int id)
        {
            List<PlaylistItem> list = new List<PlaylistItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM playlists WHERE user_id=" + id, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PlaylistItem()
                        {
                            Name = reader["name"].ToString(),
                            Vibe = reader["vibe"].ToString(),
                            DateAdded = reader["date_added"].ToString(),
                            Song_ID = Convert.ToInt32(reader["song_id"]),
                            User_ID = Convert.ToInt32(reader["user_id"])
                        });
                    }
                }
            }
            return list;
        }

        public void PostPlaylist(PlaylistItem Item)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                string insertion = "INSERT into playlists VALUES ('" + Item.Name + "', '" + Item.Vibe + "', '" + Item.DateAdded + "', " + Item.Song_ID + ", " + Item.User_ID + ");";
                MySqlCommand cmd = new MySqlCommand(insertion, conn);

                // print number of rows affected
                System.Console.WriteLine(cmd.ExecuteNonQuery());
                conn.Close();
            }
        }
    }
}
