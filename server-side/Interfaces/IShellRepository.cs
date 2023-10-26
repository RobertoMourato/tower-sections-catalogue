namespace server_side.Models;

public interface IShellRepository
{
    IEnumerable<Shell> GetShells();

    Shell GetShell(long id);
    
    bool CreateShell(Shell shells);
    
    bool DeleteShell(Shell shell);
}