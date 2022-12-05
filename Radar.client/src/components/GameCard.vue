<template>
  <div class="col-3 my-2">
    <router-link :to="{ name: 'Game', params: { gameId: game.id } }">
      <div class="card bg-darker game-card">
        <div class="card-body">

          <div class="position-relative mb-1">
            <img
              src="https://www.thetrumpet.com/files/W1siZiIsIjIwMTcvMDMvMDcvOTV0bTZvZ2szdF9maWxlIl0sWyJwIiwidGh1bWIiLCIxMDI0eCJdLFsicCIsImVuY29kZSIsImpwZyIsIi1xdWFsaXR5IDgwIl1d/64931b97734c4cff/locus_14909.jpg.jpg"
              alt="" class="img-fluid" />

            <p class="status-tag p-1 rounded m-0">{{ game.status }}</p>
            <i class="mdi mdi-lock text-light private-symbol fs-5" v-if="game.isPrivate"></i>
          </div>

          <div class="d-flex justify-content-between align-items-center">
            <h2 class="mb-1">{{ game.name }}</h2>
            <img :src="game.creator.picture" alt="" class="host-img rounded" title="Hosted by ryanthrall04@gmail.com">
          </div>
          <p>{{ game.playerCount }} of {{ game.playerLimit }} Players</p>

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
  position: absolute;
  bottom: 0;
  background-color: rgb(115, 0, 0);
}

.host-img {
  width: 3rem;
  height: 3rem;
}

.private-symbol {
  position: absolute;
  bottom: 0;
  right: 0.5rem;
}
</style>