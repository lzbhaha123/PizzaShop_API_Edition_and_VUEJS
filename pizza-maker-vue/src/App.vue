<template>
  <el-menu
    :default-active="activeIndex"
    class="el-menu-demo"
    mode="horizontal"
    background-color="#337ecc"
    text-color="#fff"
    active-text-color="#fff"
  >
    <el-menu-item index="home"><router-link to="/">Home</router-link> </el-menu-item>
    <el-menu-item index="about"><router-link to="/about">About</router-link></el-menu-item>
  </el-menu>
  <router-view/>
</template>
<script lang="ts">

import {defineComponent  } from 'vue'
import {ElMenu,ElMenuItem } from 'element-plus'


export default defineComponent ({
    components:{ElMenu,ElMenuItem  },
    /*data(){
      return{
        activeIndex:"home"
      }
    },*/
    computed:{
      activeIndex(){
        var path = this.$route.path.split('/')
        console.log(path[1])
        if(path[1]==""){
          return "home"
        }else{
          return path[1]
        }
        
      }
      
    }
});

</script>
<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
