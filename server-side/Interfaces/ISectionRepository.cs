using server_side.Models;

namespace server_side.Interfaces;

public interface ISectionRepository
{
    ICollection<Section> GetSections();

    ICollection<Section> GetSections(double? bottomDiameter, double? topDiameter);

    Section? GetSection(long id);

    Section? GetSection(string uid);

    Section CreateSection(Section section);

    // Task<Section> UpdateSection(long id, ICollection<Shell> shells);

    void DeleteSection(long id);
}