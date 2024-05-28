
using SQLite;

namespace TelefonRehberi.Helpers
{
    public static class DatabaseHelper
    {
        private const string DatabaseFileName = "Contacts.db3";

        public static string DatabasePath
        {
            get
            {
                string basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }

        public static SQLiteAsyncConnection GetDatabaseConnection()
        {
            return new SQLiteAsyncConnection(DatabasePath);
        }
    }
}

