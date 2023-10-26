using server_side.Data;

namespace server_side.Repositories;

public class ShellRepository
{
    private readonly SqliteContext sqliteContext;

    public ShellRepository(SqliteContext sqliteContext)
    {
        this.sqliteContext = sqliteContext;
    }
}