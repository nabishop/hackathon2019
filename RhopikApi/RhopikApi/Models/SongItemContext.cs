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

        public SongItem getOneSong(long id)
        {
            SongItem list = null;
            using (MySqlConnection conn = GetConnection())
            {
              
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from songs where song_id = '"+id+"';", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new SongItem()
                        {
                            song_id = Convert.ToInt32(reader["song_id"]),
                            name = reader["name"].ToString(),
                            artist = reader["artist"].ToString(),
                            genre = reader["genre"].ToString(),
                            length = reader["length"].ToString(),
                            album_covers = reader["album_covers"].ToString()
                        };
                    }
                }
            }
            return list;

        }

        public void addToDB(SongItem item)
        {
            
            string Query = "insert into songs(name , genre, length, album_covers, artist, song_id) values('" + item.name + "','" + item.genre + "','" + item.length + "','" + item.album_covers + "','" + item.artist + "', '"+item.song_id+"');";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = GetConnection();
            //This is command class which will handle the query and connection object.  
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MyConn2.Open();
            MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
            MyConn2.Close();
        }

        public void editItem(long id, SongItem item)
        {
          
            //This is my update query in which i am taking input from the user through windows forms and update the record.  
            string Query = "update songs set song_id='" + item.song_id + "',name='" + item.name + "', genre ='" + item.genre + "',length='" + item.length + "',album_covers='" + item.album_covers + "', artist='" + item.artist +"' where song_id='" + id + "';";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            MySqlConnection MyConn2 = GetConnection();
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MyConn2.Open();
            MyCommand2.ExecuteNonQuery();     
            MyConn2.Close();
        }

        public void deleteItem(long id)
        {
            
            string Query = "delete from songs where song_id='" + id + "';";
            MySqlConnection MyConn2 = GetConnection();
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);

            MyConn2.Open();
            MyCommand2.ExecuteNonQuery();
            MyConn2.Close();
        }
    }
}