<template>
  <!-- <v-app> -->
    <div>
      <main-nav />
      
      <div v-if="logged">
        <user-nav />
      
      </div>
      
      <router-view/>
    </div>
    <Footer></Footer>
  <!-- </v-app> -->
</template>

<script setup lang="ts">
  import { RouterView } from 'vue-router';
  import MainNav from './components/MainNav.vue';
  import UserNav from './components/UserNav.vue';
  import Footer from './components/Footer.vue';
  var logged = true;
  
</script>
