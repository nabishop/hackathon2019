using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace RhopikApi.Models
{
    public class SongItemContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DbSet<SongItem> SongItems { get; set; }


        public SongItemContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<SongItem> getAllSongs()
        {
            List<SongItem> list = new List<SongItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from songs", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SongItem()
                        {
                            song_id = Convert.ToInt32(reader["song_id"]),
                            name = reader["name"].ToString(),
                            artist = reader["artist"].ToString(),
                            genre = reader["genre"].ToString(),
                            length = reader["length"].ToString(),
                            album_covers = reader["album_covers"].ToString()
                        });
                    }
                }
            }
            return list;

        }
    }
}