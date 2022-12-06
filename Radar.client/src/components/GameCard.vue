<template>
  <div class="col-12 my-2">
    <router-link :to="{ name: 'Game', params: { gameId: game.id } }">
      <div class="card bg-darker game-card">
        <div class="card-body">

          <!-- <p class="status-tag p-1 rounded m-0">{{ game.status }}</p> -->
          <!-- <i class="mdi mdi-lock text-light private-symbol fs-5" v-if="game.isPrivate"></i> -->

          <div class="d-flex justify-content-between align-items-center">
            <h2 class="mb-1">{{ game.name }}</h2>
            <p class="m-0">{{ game.playerCount }} of {{ game.playerLimit }} Players</p>
            <p class="status-tag p-1 rounded m-0">{{ game.status }}</p>
            <img :src="game.creator.picture" alt="" class="host-img rounded" title="Hosted by ryanthrall04@gmail.com">
          </div>

        </div>
      </div>
    </router-link>
  </div>
</template>


<script>
import { Game } from '../models/Game.js';

export default {
  props: {
    game: {
      type: Game,
      required: true
    }
  },
  setup(props) {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.status-tag {
  background-color: rgb(115, 0, 0);
}

.host-img {
  width: 3rem;
  height: 3rem;
}
</style>