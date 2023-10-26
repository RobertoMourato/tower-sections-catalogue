using server_side.Data;

namespace server_side.Repositories;

public class SectionRepository
{
    private readonly SqliteContext sqliteContext;

    public SectionRepository(SqliteContext sqliteContext)
    {
        this.sqliteContext = sqliteContext;
    }
}