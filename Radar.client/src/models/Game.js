

export class Game {
  constructor(data) {
    this.id = data.id;
    this.createdAt = data.createdAt;
    this.updatedAt = data.updatedAt;
    this.creator = data.creator;
    this.creatorId = data.creatorId;
    this.isPrivate = data.isPrivate;
    this.map = data.map;
    this.mapId = data.mapId;
    this.name = data.name;
    this.pin = data.pin;
    this.playerCount = data.playerCount;
    this.playerLimit = data.playerLimit;
    this.status = data.status;
    this.type = data.type;
    this.winner = data.winner;
    this.winnerId = data.winnerId;
  }
}