namespace Radar.Models;

public class Map : IDbItem<int>
{
  // IDbItem
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  // Map Specific
  string name { get; set; }
  int size { get; set; }
  int gameId { get; set; }

}