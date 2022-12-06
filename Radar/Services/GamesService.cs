namespace Radar.Services;

public class GamesService
{
  private readonly GamesRepo _gamesRepo;
  // private readonly PlayersService _playersServ;
  //PlayersService playersServ
  public GamesService(GamesRepo gamesRepo)
  {
    _gamesRepo = gamesRepo;
    // _playersServ = playersServ;
  }

  public Game HostGame(Game data, Account userInfo)
  {
    // Force User to be the creator
    data.CreatorId = userInfo.Id;

    // Force Status to be waiting for players
    data.Status = "Waiting for players";

    data.Type = "Hosted";

    // Create the Game Object and Give it the Creator Data
    Game game = _gamesRepo.CreateGame(data);
    game.Creator = userInfo;




    return game;
  }

  public List<Game> GetJoinableGames()
  {
    List<Game> games = _gamesRepo.GetJoinableGames();
    return games;
  }

  public Game GetGameById(int gameId)
  {
    Game game = _gamesRepo.GetGameById(gameId);
    if (game == null)
    {
      throw new Exception("Bad Game Id!");
    }
    return game;
  }

  public List<Game> GetMyGames(string userId)
  {
    List<Game> games = _gamesRepo.GetMyGames(userId);

    return games;
  }
}