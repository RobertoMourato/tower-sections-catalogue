using server_side.Models;

namespace server_side.Interfaces;

public interface ISectionRepository
{
    ICollection<Section> GetSections();

    ICollection<Section> GetSections(double? bottomDiameter, double? topDiameter);

    Section? GetSection(long id);

    Section? GetSection(string uid);

    ICollection<Shell> GetShells(long id);

    bool CreateSection(Section section, List<long> shellIds);

    bool UpdateSection(Section section, List<long> shellIds);

    bool DeleteSection(Section section);

    bool Save();
}