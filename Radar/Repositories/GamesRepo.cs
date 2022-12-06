namespace Radar.Repositories;

public class GamesRepo : BaseRepo
{
  // SECTION Constructor
  public GamesRepo(IDbConnection db) : base(db)
  {
  }

  public Game CreateGame(Game data)
  {

    // Sql Commands to Make a Game Object
    string sql = @"
    INSERT INTO games(creatorId, name, playerLimit, isPrivate, pin, status, type)
    VALUES(@CreatorId, @Name, @PlayerLimit, @IsPrivate, @Pin, @Status, @Type);
    SELECT LAST_INSERT_ID()
    ;";

    // Set The Created Time for this keep
    data.CreatedAt = DateTime.Now;
    data.UpdatedAt = DateTime.Now;

    // Run the SQL and return the object created
    data.Id = _db.ExecuteScalar<int>(sql, data);
    return data;
  }

  public List<Game> GetJoinableGames()
  {
    string status = "Waiting for players";
    string sql = @"
      SELECT 
      g.*,
      COUNT(p.id) AS playerCount,
      a.*
      FROM games g
      JOIN accounts a on a.id = g.creatorId
      LEFT JOIN players p ON p.gameId = g.id
      WHERE g.status = @status 
      GROUP BY g.id
    ;";

    return _db.Query<Game, Account, Game>(sql, (g, a) =>
    {
      g.Creator = a;
      return g;
    }, new { status }).ToList();

  }

  public Game GetGameById(int gameId)
  {
    string sql = @"
    SELECT
    g.*,
    COUNT(p.id) AS playerCount,
    a.*
    FROM games g
    JOIN accounts a ON a.id = g.creatorId
    LEFT JOIN players p ON p.gameId = g.id
    WHERE g.id = @gameId
    GROUP BY g.id
    ;";

    return _db.Query<Game, Account, Game>(sql, (g, a) =>
    {
      g.Creator = a;
      return g;
    }, new { gameId }).FirstOrDefault();
  }

  public List<Game> GetMyGames(string userId)
  {

    string sql = @"
      SELECT 
      g.*,
      COUNT(p.id) AS playerCount,
      a.*
      FROM games g
      JOIN accounts a on a.id = g.creatorId
      LEFT JOIN players p ON p.gameId = g.id
      WHERE p.creatorId = @userId
      GROUP BY g.id
    ;";

    return _db.Query<Game, Account, Game>(sql, (g, a) =>
    {
      g.Creator = a;
      return g;
    }, new { userId }).ToList();

  }
}