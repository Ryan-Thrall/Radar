namespace Radar.Services;

public class GamesService
{
  private readonly GamesRepo _gamesRepo;

  public GamesService(GamesRepo gamesRepo)
  {
    _gamesRepo = gamesRepo;
  }

  public Game CreateGame(Game data, Account userInfo)
  {
    // Force User to be the creator
    data.CreatorId = userInfo.Id;

    // Force Status to be waiting for players
    data.Status = "Waiting for players";

    Game game = _gamesRepo.CreateGame(data);
    game.Creator = userInfo;
    return game;
  }
}