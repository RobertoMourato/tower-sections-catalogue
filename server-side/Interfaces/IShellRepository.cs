using server_side.Models;

namespace server_side.Interfaces;

public interface IShellRepository
{
    ICollection<Shell> GetShells();

    Shell GetShell(long id);

    bool CreateShell(Shell shells);

    bool DeleteShell(Shell shell);
}