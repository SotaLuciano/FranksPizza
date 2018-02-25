using SQLite;

namespace Franks_Pizza
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
