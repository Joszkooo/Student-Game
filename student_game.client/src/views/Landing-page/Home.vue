<template>
    <div class="text-center p-20 m-20" >
        <h1 class="text-7xl text-slate-100 text-center pt-3 font-bold header-landing">
            Stwórz swojego
            <span class="block text-transparent bg-clip-text bg-gradient-to-r from-blue-500 via-pink-500 to-blue-500">Studenta</span>
        </h1>
        <p class="pt-3 font-medium text-xl text-gray-200">&& pokonaj wszystkich na swojej drodze</p>
        <Button class="rounded-full mt-2 shadow-neon bg-black-500"> 
            <router-link :to="{ name: 'Login' }">Zacznij teraz!</router-link>
        </Button>
        
        <div class="grid grid-cols-4 gap-6 content-center p-9 ">
            <div class="relative m-5 px-6 rounded-lg h-48 shadow-2xl overflow-hidden flex items-center">
                <div class="absolute inset-0 bg-one bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center space-y-2">
                    <h1 class="text-lg font-bold">Walcz z przeciwnikami</h1>
                    <p class="text-sm font-light">
                        Doświadcz setki wrogów którzy czekają aż się z nimi zmierzysz.
                    </p>
                </div>
            </div>
            <div class="relative m-5 px-6 rounded-lg h-48 shadow-2xl overflow-hidden flex items-center">
                <div class="absolute inset-0 bg-two bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center space-y-2">
                    <h1 class="text-lg font-bold">Zdobywaj epickie przedmioty</h1>
                    <p class="text-sm font-light">
                        Odkrywaj niesamowite przedmioty i spróbuj zebrać je wszystkie!
                    </p>
                </div>
            </div>
            <div class="relative m-5 px-6 rounded-lg h-48 shadow-2xl overflow-hidden flex items-center">
                <div class="absolute inset-0 bg-three bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center space-y-2">
                    <h1 class="text-lg font-bold">Rozmawiaj z innymi</h1>
                    <p class="text-sm font-light">
                        Poznawaj i twórz przyjaźnie na wiele lat podczas swojej przygody.
                    </p>
                </div>
            </div>
            <div class="relative m-5 px-6 rounded-lg h-48 shadow-2xl overflow-hidden flex items-center">
                <div class="absolute inset-0 bg-four bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center space-y-2">
                    <h1 class="text-lg font-bold">Leveluj do granic możliwości</h1>
                    <p class="text-sm font-light">
                        Podbij ranking sam lub ze znajomymi i walcz o pierwsze miejsce!
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
    import { Button } from '@/components/ui/button'
</script>
