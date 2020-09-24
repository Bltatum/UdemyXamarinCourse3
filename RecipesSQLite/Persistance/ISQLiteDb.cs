using System;
using SQLite;

namespace RecipesSQLite.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
