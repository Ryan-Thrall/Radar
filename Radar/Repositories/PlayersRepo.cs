namespace Radar.Repositories;

public class PlayersRepo : BaseRepo
{
  public PlayersRepo(IDbConnection db) : base(db)
  {
  }

  public Player JoinGame(Player data)
  {

    string sql = @"
    INSERT INTO players(creatorId, faction, playerNum, gameId, status)
    VALUES(@CreatorId, @Faction, @PlayerNum, @GameId, @Status);
    SELECT LAST_INSERT_ID()
    ;";

    // Set The Created Time for this keep
    data.CreatedAt = DateTime.Now;
    data.UpdatedAt = DateTime.Now;

    // Run the Sql and Return the Object Created
    data.Id = _db.ExecuteScalar<int>(sql, data);
    return data;
  }

  public List<Player> GetPlayersByGameId(int gameId)
  {
    string sql = @"
    SELECT
    p.*,
    a.*
    FROM players p
    JOIN accounts a ON a.id = p.creatorId
    WHERE p.gameId = @gameId
    GROUP BY p.id
    ;";

    return _db.Query<Player, Account, Player>(sql, (p, a) =>
    {
      p.Creator = a;
      return p;
    }, new { gameId }).ToList();
  }
}