<template>
  <div class="container-fluid">
    <div class="row mt-5 justify-content-center">
      <div class="col-12">

        <div class="d-flex">

          <div class="tab d-flex justify-content-center selectable"
            :class="tab == 'myGames' ? 'bg-darkerGreen' : 'bg-darkGreen'" @click="switchTab('myGames')">
            <h5 class="px-4 pt-2">My Games</h5>
          </div>

          <div class="bg-darkGreen tab d-flex justify-content-center selectable"
            :class="tab == 'publicGames' ? 'bg-darkerGreen' : 'bg-darkGreen'" @click="switchTab('publicGames')">
            <h5 class="px-4 pt-2">Public Games</h5>
          </div>

          <div class="bg-darkGreen tab d-flex justify-content-center selectable"
            :class="tab == 'hostAGame' ? 'bg-darkerGreen' : 'bg-darkGreen'" @click="switchTab('hostAGame')">
            <h5 class="px-4 pt-2">Host a Game</h5>
          </div>

          <div class="bg-darkGreen tab d-flex justify-content-center"
            :class="tab == 'casualMatch' ? 'bg-darkerGreen' : 'bg-darkGreen'" @click="switchTab('casualMatch')">
            <h5 class="px-4 pt-2">Casual Match</h5>
          </div>

          <div class="bg-darkGreen tab d-flex justify-content-center"
            :class="tab == 'rankedMatch' ? 'bg-darkerGreen' : 'bg-darkGreen'" @click="switchTab('rankedMatch')">
            <h5 class="px-4 pt-2">Ranked Match</h5>
          </div>

        </div>

        <div class="bg-darkest game-menu">
          <div class="row">

            <!-- <p class="status-tag p-1 rounded m-0">{{ game.status }}</p> -->
            <!-- <i class="mdi mdi-lock text-light private-symbol fs-5" v-if="game.isPrivate"></i> -->

            <div class="d-flex justify-content-between align-items-center px-3 game-label bg-darkest py-2 pt-3"
              v-if="tab == 'myGames' || tab == 'publicGames'">
              <h3 class="mb-0 ms-4"> Game Name</h3>
              <h3 class="mb-0 me-3"># of Players</h3>
              <h3 class="mb-0 me-4">Status</h3>
              <h3 class="mb-0 me-2">Host</h3>
            </div>

            <GameCard v-for="g in myGames" :game="g" :key="g.id" v-if="tab == 'myGames'" />
            <GameCard v-for="g in publicGames" :game="g" :key="g.id" v-if="tab == 'publicGames'" />
          </div>
        </div>

      </div>
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
      publicGames: computed(() => AppState.publicGames),
      myGames: computed(() => AppState.myGames),
      tab: computed(() => AppState.gameMenuTab),

      switchTab(tabName) {
        AppState.gameMenuTab = tabName;
      }
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

.game-menu {
  position: relative;
  height: 75vh;
  overflow-x: hidden;
  overflow-y: scroll;
}

.game-label {
  position: sticky;
  top: 0;
  // border-bottom: 2px solid white;
  z-index: 1;
}

.tab {
  overflow: hidden;
  clip-path: polygon(15% 0, 85% 0, 100% 100%, 0% 100%);
}
</style>
