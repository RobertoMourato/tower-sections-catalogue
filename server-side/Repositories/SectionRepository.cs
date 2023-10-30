using server_side.Database;
using server_side.Interfaces;
using server_side.Models;

namespace server_side.Repositories;

public class SectionRepository : ISectionRepository
{
    private readonly SqliteContext sqliteContext;

    public SectionRepository(SqliteContext sqliteContext)
    {
        this.sqliteContext = sqliteContext;
    }

    public ICollection<Section> GetSections()
    {
        return sqliteContext.Sections.OrderBy(se => se.Id).ToList();
    }

    public ICollection<Section> GetSections(double? bottomDiameter, double? topDiameter)
    {
        if (bottomDiameter != null && topDiameter != null)
        {
            return sqliteContext.Sections.Where(se => se.BottomDiameter == bottomDiameter).Where(se => se.TopDiameter == topDiameter).OrderBy(se => se.Id).ToList();
        }
        else if (bottomDiameter != null)
        {
            return sqliteContext.Sections.Where(se => se.BottomDiameter == bottomDiameter).OrderBy(se => se.BottomDiameter).ToList();
        }
        else if (topDiameter != null)
        {
            return sqliteContext.Sections.Where(se => se.TopDiameter == topDiameter).OrderBy(se => se.TopDiameter).ToList();
        }

        return sqliteContext.Sections.OrderBy(se => se.Id).ToList();
    }

    public Section? GetSection(long id)
    {
        return sqliteContext.Sections.Where(se => se.Id == id).FirstOrDefault();
    }

    public Section? GetSection(string uid)
    {
        return sqliteContext.Sections.Where(se => se.PartNumber == uid).FirstOrDefault();
    }

    public ICollection<Shell> GetShells(long id)
    {
        return sqliteContext.SectionShells.Where(ss => ss.Section.Id == id).OrderBy(ss => ss.ShellPosition).Select(ss => ss.Shell).ToList();
    }

    public bool CreateSection(Section section, List<long> shellIds)
    {
        for (var i = 1; i <= shellIds.Count; i++)
        {
            var shell = sqliteContext.Shells.Where(sh => sh.Id == shellIds[i - 1]).FirstOrDefault();

            if (shell != null)
            {
                var sectionShell = new SectionShell()
                {
                    ShellId = shell.Id,
                    ShellPosition = i,
                    Section = section,
                    Shell = shell,
                };

                sqliteContext.Add(sectionShell);
            }
        }

        sqliteContext.Add(section);
        return Save();
    }

    public void DeleteSection(long id)
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        return sqliteContext.SaveChanges() > 0;
    }
}