namespace Radar.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GamesController : ControllerBase
{
  // SECTION Used Files
  private readonly GamesService _gamesServ;
  private readonly PlayersService _playersServ;
  private readonly Auth0Provider _auth0;

  // SECTION Constructor
  public GamesController(Auth0Provider auth0, GamesService gamesServ, PlayersService playersServ)
  {
    _gamesServ = gamesServ;
    _playersServ = playersServ;
    _auth0 = auth0;
  }

  // SECTION Post
  // Create Game
  [Authorize]
  [HttpPost("Host")]
  public async Task<ActionResult<Game>> HostGame([FromBody] Game data)
  {
    try
    {
      // Access User Info or throw error
      var userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      if (userInfo == null || userInfo.Id == null)
      {
        throw new Exception("Cannot Access Account. Relogin and try again.");
      }

      // Create and return a Hosted Game
      Game game = _gamesServ.HostGame(data, userInfo);

      Player playerData = new Player()
      {
        GameId = game.Id
      };

      Player player = _playersServ.JoinGame(playerData, userInfo);

      // Return game object
      return Ok(game);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  // SECTION Get
  // Get Not Started Joinable Games
  [HttpGet()]
  public ActionResult<Game> GetJoinableGames()
  {
    try
    {
      List<Game> games = _gamesServ.GetJoinableGames();
      return Ok(games);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpGet("myGames")]
  public async Task<ActionResult<Game>> GetMyGames()
  {
    try
    {
      // Access User Info or throw error
      var userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      if (userInfo == null || userInfo.Id == null)
      {
        throw new Exception("Cannot Access Account. Relogin and try again.");
      }

      List<Game> games = _gamesServ.GetMyGames(userInfo.Id);

      return Ok(games);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}