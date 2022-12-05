<template>
  <div class="container-fluid">
    <div class="row" v-if="account.id">
      <div class="col-12">
        <h1 class="mt-3">Your Games</h1>
      </div>

      <GameCard v-for="g in publicGames" :game="g" :key="g.id" />

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
