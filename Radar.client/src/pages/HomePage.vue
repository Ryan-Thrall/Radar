<template>
  <div class="container-fluid">
    <div class="row" v-if="account.id">
      <div class="col-12">
        <h1 class="mt-3">Your Games</h1>
      </div>

      <div class="col-3 my-2">
        <div class="card bg-darker game-card">
          <div class="card-body">

            <div class="position-relative mb-1">
              <img
                src="https://www.thetrumpet.com/files/W1siZiIsIjIwMTcvMDMvMDcvOTV0bTZvZ2szdF9maWxlIl0sWyJwIiwidGh1bWIiLCIxMDI0eCJdLFsicCIsImVuY29kZSIsImpwZyIsIi1xdWFsaXR5IDgwIl1d/64931b97734c4cff/locus_14909.jpg.jpg"
                alt="" class="img-fluid" />

              <p class="status-tag p-1 rounded m-0">Waiting For Players</p>
              <i class="mdi mdi-lock text-light private-symbol fs-5"></i>
            </div>

            <div class="d-flex justify-content-between align-items-center">
              <h2 class="mb-1">Game Name</h2>
              <img :src="account.picture" alt="" class="host-img rounded" title="Hosted by ryanthrall04@gmail.com">
            </div>
            <p>3 of 4 Players</p>

          </div>
        </div>
      </div>

    </div>

    <div class="row">
      <div class="col-12">
        <h1 class="mt-3">Join a Game</h1>
      </div>

      <GameCard v-for="g in publicGames" :game="g" :key="g.id" />
    </div>

  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { gamesService } from '../services/GamesService.js'
import Pop from '../utils/Pop.js';

export default {
  setup() {
    async function getJoinableGames() {
      try {
        await gamesService.getJoinableGames();
      } catch (error) {
        Pop.error(error, "[Getting Joinable Games]")
      }
    }

    onMounted(() => {
      getJoinableGames();
    })

    return {
      account: computed(() => AppState.account),
      publicGames: computed(() => AppState.publicGames)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
