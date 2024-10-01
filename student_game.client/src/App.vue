<template>
  <!-- <v-app> -->
    <div>
      <main-nav />
      
      <div v-if="logged">
        <user-nav />
      
      </div>
      
      <router-view/>
    </div>
  <!-- </v-app> -->
</template>

<script setup lang="ts">
  import { RouterView } from 'vue-router';
  import MainNav from './components/MainNav.vue';
  import UserNav from './components/UserNav.vue';
  var logged = true;
</script>
