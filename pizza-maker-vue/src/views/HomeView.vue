<template>
  <div class="home">
    <!--<img alt="Vue logo" src="../assets/logo.png">-->
    <PizzaList/>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import PizzaList from '@/components/PizzaList.vue'; // @ is an alias to /src

@Options({
  components: {
    PizzaList,
  },
})
export default class HomeView extends Vue {}
</script>
