<template>
    <header class="top-0 shadow-lg">
        
        <nav class="container flex flex-col sm:flex-row gap-4 lg:space-x-6 text-white py-5 items-center justify-between">
            
            <div class="text-2xl bg-gradient-to-r from-slate-50 via-gray-100 to-zinc-200 bg-clip-text text-transparent">
                <router-link class="lg:space-x-6 " to="/">Student game</router-link>
            </div>
            
            <div class="flex gap-7 flex-1 justify-end">
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Contact' }">Contact</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'About' }">About</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300" href="https://github.com/Joszkooo" target="_blank">Other projects</a>
                <Button class="px-5 mt-5 shadow-neon bg-black-500 cursor-pointer duration-100 rounded-full"><router-link :to="{ name: 'Login' }">Zaloguj się!</router-link></Button>
            </div>
        </nav>
    </header>

</template>

<script setup>
    import { Button } from '@/components/ui/button'
</script>

