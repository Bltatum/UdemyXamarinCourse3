using System;
using System.IO;
using ContactBookSQLExercise.iOS.Persistance;
using ContactBookSQLExercise.Persistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace ContactBookSQLExercise.iOS.Persistance
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
