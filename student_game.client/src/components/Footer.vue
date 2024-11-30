<template>
    <footer class="footer-background text-gray-300 py-8">
      <div class="container mx-auto text-center">
      
        <h2 class="text-lg font-bold text-white mb-4">StudentGame.online</h2>
  
        <nav class="flex justify-center space-x-6 mb-6 text-sm">
          <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Contact' }">Contact</router-link></a>
          <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'About' }">About</router-link></a>
          <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300" href="https://github.com/Joszkooo" target="_blank">Other projects</a>
        </nav>
  
        <div class="flex justify-center space-x-4 mb-6">
          <v-btn icon small color="grey-lighten-2">
            <v-icon>mdi-twitter</v-icon>
          </v-btn>
          <v-btn icon small color="grey-lighten-2">
            <v-icon>mdi-facebook</v-icon>
          </v-btn>
          <v-btn icon small color="grey-lighten-2">
            <v-icon>mdi-instagram</v-icon>
          </v-btn>
        </div>
  
        <div class="text-sm text-gray-500">
          © 2024 StudentGame.online. All rights reserved.
        </div>
      </div>
    </footer>
  </template>
  
  <script setup>
  import { VBtn, VIcon } from "vuetify/components";
  </script>
  
  <style scoped>
  footer {
    border-top: 1px solid #333;
  }
  </style>