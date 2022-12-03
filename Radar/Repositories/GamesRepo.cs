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
    INSERT INTO games(creatorId, name, playerLimit, isPrivate, pin, status)
    VALUES(@CreatorId, @Name, @PlayerLimit, @IsPrivate, @Pin, @Status);
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
    // Sql Commands to Make a Game Object
    string sql = @"
      SELECT 
      g.*,
      a.*
      FROM games g
      JOIN accounts a on a.id = g.creatorId
      WHERE g.status = @status 
      GROUP BY g.id
    ;";

    return _db.Query<Game, Account, Game>(sql, (g, a) =>
    {
      g.Creator = a;
      return g;
    }, new { status }).ToList();

  }
}