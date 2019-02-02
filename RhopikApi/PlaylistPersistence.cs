using RhopikApi.Models;

namespace RhopikApi
{
    public class PlaylistPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;

        public PlaylistPersistence()
        {
            string myConnectionString = "server=slohacks2019.mysql.database.azure.com;";
            myConnectionString += "uid=tschoppcity@slohacks2019;";
            myConnectionString += "pwd=password_1;";
            myConnectionString += "database=slohacks";

            try
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection();
                connection.ConnectionString = myConnectionString;
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        // returns -1 on fail
        public long savePlaylist(PlaylistItem item)
        {
            string sqlString = "INSERT INTO playlists (name, vibe, date_added, song_id, user_id) VALUES ('" + item.Name + "','" +
                item.Vibe + "','" + item.DateAdded + "'," + item.SongId + "," + item.UserId + ")";

            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection);
                cmd.ExecuteNonQuery();


                long id = cmd.LastInsertedId;
                return id;
            }
            catch (MySql.Data.MySqlClient.MySqlException exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);

                return -1;
            }
        }

    }
}
