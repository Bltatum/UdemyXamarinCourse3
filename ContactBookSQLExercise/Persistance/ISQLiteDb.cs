using System;
using SQLite;

namespace ContactBookSQLExercise.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
