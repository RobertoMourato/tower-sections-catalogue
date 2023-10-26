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

    public Section GetSectionByPartNumber(string uid)
    {
        throw new NotImplementedException();
    }

    public ICollection<Section> GetSectionsByDiameter(double bottomDiameter, double topDiameter)
    {
        throw new NotImplementedException();
    }

    public Section CreateSection(Section section)
    {
        throw new NotImplementedException();
    }

    public void DeleteSection(long id)
    {
        throw new NotImplementedException();
    }
}