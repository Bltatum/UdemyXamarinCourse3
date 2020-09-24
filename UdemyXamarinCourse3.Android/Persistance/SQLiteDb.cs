using System;
using System.IO;
using SQLite;
using UdemyXamarinCourse3.Droid.Persistance;
using UdemyXamarinCourse3.Persistance;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace UdemyXamarinCourse3.Droid.Persistance
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
