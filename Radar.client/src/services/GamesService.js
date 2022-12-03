import { AppState } from "../AppState.js";
import { Game } from "../models/Game.js";
import { api } from "./AxiosService.js";


class GamesService {
  async getJoinableGames() {
    const res = await api.get('api/games')
    // console.log(res.data)
    AppState.publicGames = res.data.map(g => new Game(g))
  }
}

export const gamesService = new GamesService();