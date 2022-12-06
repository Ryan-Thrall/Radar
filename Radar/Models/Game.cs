namespace Radar.Models;

public class Game : IHasCreator
{
  // IHasCreator
  public string CreatorId { get; set; }
  public Account Creator { get; set; }

  // IDbItem
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int Id { get; set; }

  // Game Specific
  public string Name { get; set; }
  public int MapId { get; set; }
  public int PlayerLimit { get; set; }
  public bool IsPrivate { get; set; }
  public int Pin { get; set; }
  public int PlayerCount { get; set; }
  public string Status { get; set; }
  public string Type { get; set; }
  public string WinnerId { get; set; }
  public Account Winner { get; set; }
  public Map Map { get; set; }
}