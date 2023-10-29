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

    public Section CreateSection(Section section)
    {
        throw new NotImplementedException();
    }

    public void DeleteSection(long id)
    {
        throw new NotImplementedException();
    }
}