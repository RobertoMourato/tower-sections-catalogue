namespace server_side.Models;

public interface ISectionRepository
{
    Section GetSectionByPartNumber(string uid);

    Section CreateSection(Section section);

    // Task<Section> UpdateSection(long id, IEnumerable<Shell> shells);

    void DeleteSection(long id);

    IEnumerable<Section> GetSectionsByDiameter(double bottomDiameter, double topDiameter);
}