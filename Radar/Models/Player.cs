namespace Radar.Models;

public class Player : IHasCreator
{
  // IHasCreator
  public string CreatorId { get; set; }
  public Account Creator { get; set; }

  // IDbItem
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  // Player Specific
  public string Faction { get; set; }
  public int PlayerNum { get; set; }
  public int GameId { get; set; }
  public string Status { get; set; }
  public string TechTree { get; set; }
  public string Resources { get; set; }
  public Game Game { get; set; }

}