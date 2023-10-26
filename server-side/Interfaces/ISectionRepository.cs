using server_side.Models;

namespace server_side.Interfaces;

public interface ISectionRepository
{
    ICollection<Section> GetSections();

    Section? GetSectionByPartNumber(string uid);

    ICollection<Section> GetSectionsByDiameter(double? bottomDiameter, double? topDiameter);

    Section CreateSection(Section section);

    // Task<Section> UpdateSection(long id, ICollection<Shell> shells);

    void DeleteSection(long id);
}