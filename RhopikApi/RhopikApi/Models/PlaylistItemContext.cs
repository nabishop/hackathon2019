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

    }
}
