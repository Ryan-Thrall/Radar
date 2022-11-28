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
}