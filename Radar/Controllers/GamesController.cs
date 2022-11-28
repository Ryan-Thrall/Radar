namespace Radar.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GamesController : ControllerBase
{
  // SECTION Used Files
  private readonly GamesService _gamesServ;
  private readonly Auth0Provider _auth0;

  // SECTION Constructor
  public GamesController(Auth0Provider auth0, GamesService gamesServ)
  {
    _gamesServ = gamesServ;
    _auth0 = auth0;
  }

  // SECTION Post
  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Game>> CreateGame([FromBody] Game data)
  {
    try
    {
      // Access User Info or throw error
      var userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      if (userInfo == null || userInfo.Id == null)
      {
        throw new Exception("Cannot Access Account. Relogin and try again.");
      }

      // Create and return a game
      Game game = _gamesServ.CreateGame(data, userInfo);

      // Return game object
      return Ok(game);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}