using System;
using System.IO;
using RecipesSQLite.Droid.Persistance;
using RecipesSQLite.Persistance;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace RecipesSQLite.Droid.Persistance
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
