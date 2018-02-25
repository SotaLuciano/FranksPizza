using Franks_Pizza.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Franks_Pizza.Droid
{
    public class SQLite_Android : ISQLiteDb
    {
        #region ISQLite implementation
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "NewFranksPizzaDatabase.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLiteAsyncConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}