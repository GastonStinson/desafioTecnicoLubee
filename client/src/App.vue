<template>
  <div class="mainContainer">
    <SearchById />
  </div>
</template>

<script>
import SearchById from './components/SearchById.vue';

export default {
  name: 'App',
  components: {
    SearchById,
  }
}
</script>

<style>
.mainContainer {
  background-color: rgb(191, 191, 191);
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100vw;
  height: 100vh;
}
</style>
