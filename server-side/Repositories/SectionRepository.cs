using System.ComponentModel.DataAnnotations;
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

    public Section? GetSectionByPartNumber(string uid)
    {
        return sqliteContext.Sections.Where(se => se.PartNumber == uid).FirstOrDefault();
    }

    public ICollection<Section> GetSectionsByDiameter(double? bottomDiameter, double? topDiameter)
    {
        if (bottomDiameter != null && topDiameter != null)
        {
            return sqliteContext.Sections.Where(se => se.BottomDiameter == bottomDiameter).Where(se => se.TopDiameter == topDiameter).ToList();
        }
        else if (bottomDiameter != null)
        {
            return sqliteContext.Sections.Where(se => se.BottomDiameter == bottomDiameter).ToList();
        }
        else if (topDiameter != null)
        {
            return sqliteContext.Sections.Where(se => se.TopDiameter == topDiameter).ToList();
        }

        return new List<Section>();
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