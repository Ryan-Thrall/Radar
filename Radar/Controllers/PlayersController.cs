namespace Radar.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PlayersController : ControllerBase
{
  // SECTION Used Files
  private readonly PlayersService _playersServ;
  private readonly Auth0Provider _auth0;

  public PlayersController(Auth0Provider auth0, PlayersService playersServ)
  {
    _playersServ = playersServ;
    _auth0 = auth0;
  }

  // SECTION Post
  // Join Game
  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Player>> JoinGame([FromBody] Player data)
  {
    try
    {
      // Access User Info or throw error
      var userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      if (userInfo == null || userInfo.Id == null)
      {
        throw new Exception("Cannot Access Account. Relogin and try again.");
      }

      // Join a Game and return the player
      Player player = _playersServ.JoinGame(data, userInfo);

      // Return player object
      return Ok(player);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}