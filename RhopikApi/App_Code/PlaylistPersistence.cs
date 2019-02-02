using MySql.Data;

namespace RhopikApi.App_Code
{
    public class PlaylistPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;

        public PlaylistPersistence()
        {
            string myConnectionString = "slohacks2019.mysql.database.azure.com";
        }

    }
}
