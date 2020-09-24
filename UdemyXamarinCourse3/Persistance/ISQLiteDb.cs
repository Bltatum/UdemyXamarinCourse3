using System;
using SQLite;

namespace UdemyXamarinCourse3.Persistance
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
