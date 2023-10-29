using server_side.Database;
using server_side.Interfaces;
using server_side.Models;

namespace server_side.Repositories;

public class ShellRepository : IShellRepository
{
    private readonly SqliteContext sqliteContext;

    public ShellRepository(SqliteContext sqliteContext)
    {
        this.sqliteContext = sqliteContext;
    }

    public ICollection<Shell> GetShells()
    {
        return sqliteContext.Shells.OrderBy(sh => sh.Id).ToList();
    }

    public Shell? GetShell(long id)
    {
        return sqliteContext.Shells.Where(sh => sh.Id == id).FirstOrDefault();
    }

    public bool CreateShell(Shell shells)
    {
        throw new NotImplementedException();
    }

    public bool DeleteShell(Shell shell)
    {
        throw new NotImplementedException();
    }
}