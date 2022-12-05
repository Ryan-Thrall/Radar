namespace Radar.Services;

public class PlayersService
{
  private readonly PlayersRepo _playersRepo;
  private readonly GamesService _gamesServ;

  public PlayersService(PlayersRepo playersRepo, GamesService gamesServ)
  {
    _playersRepo = playersRepo;
    _gamesServ = gamesServ;
  }

  public Player JoinGame(Player data, Account userInfo)
  {
    // Force User to be the creator
    data.CreatorId = userInfo.Id;

    // Get the game for the player count
    Game game = _gamesServ.GetGameById(data.GameId);

    // Get players of this game
    List<Player> players = this.GetPlayersByGameId(data.GameId);

    // Set the player num to the number of players already + 1
    data.PlayerNum = game.PlayerCount + 1;

    // Set the status to waiting to play
    data.Status = "Waiting to Play";

    // Throw error if game is full
    if (game.PlayerLimit == game.PlayerCount)
    {
      throw new Exception("This Game is Full!");
    }

    // Throw error if game is already started
    if (game.Status != "Waiting for players")
    {
      throw new Exception("This Game has Already Started!");
    }

    // TODO
    foreach (Player p in players)
    {
      if (p.CreatorId == userInfo.Id)
      {
        throw new Exception("You Already Joined this Game");
      }
    }


    Player player = _playersRepo.JoinGame(data);
    player.Creator = userInfo;
    return player;
  }

  public List<Player> GetPlayersByGameId(int gameId)
  {

    List<Player> players = _playersRepo.GetPlayersByGameId(gameId);
    return players;
  }
}