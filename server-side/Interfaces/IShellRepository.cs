using server_side.Models;

namespace server_side.Interfaces;

public interface IShellRepository
{
    ICollection<Shell> GetShells();

    Shell? GetShell(long id);

    bool CreateShell(Shell shell);

    bool DeleteShell(Shell shell);

    bool Save();
}