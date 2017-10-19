using System;
using SQLite;

namespace BelzonaMobile
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection();
        long GetSize();
        Boolean DatabaseExist();
        void CloseConnection();
        //SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}
