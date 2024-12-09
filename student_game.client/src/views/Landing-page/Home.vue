<template>
    <div class="text-center p-20 m-20 min-h-screen">
        <h1 class="text-7xl text-slate-100 text-center pt-3 font-bold header-landing">
            Stwórz swojego
            <span class="block text-transparent bg-clip-text bg-gradient-to-r from-blue-500 via-pink-500 to-blue-500">Studenta</span>
        </h1>
        <p class="pt-3 font-medium text-xl text-gray-200">&& pokonaj wszystkich na swojej drodze</p>
        <Button class="rounded-full mt-5 shadow-neon bg-black-500"> 
            Zacznij teraz!
        </Button>
        
        <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-8 p-8 content-center mt-20">
            <div class="relative m-6 p-6 sm:p-8 rounded-lg min-h-64 shadow-2xl overflow-hidden flex flex-col justify-center">
                <div class="absolute inset-0 bg-one bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center">
                    <h1 class="text-xl sm:text-2xl font-bold mb-2">Walcz z przeciwnikami</h1>
                    <p class="text-sm sm:text-base font-light leading-snug">
                        Doświadcz setki wrogów którzy czekają aż się z nimi zmierzysz.
                    </p>
                </div>
            </div>
            <div class="relative m-6 p-6 sm:p-8 rounded-lg min-h-64 shadow-2xl overflow-hidden flex flex-col justify-center">
                <div class="absolute inset-0 bg-two bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center">
                    <h1 class="text-xl sm:text-2xl font-bold mb-2">Zdobywaj epickie przedmioty</h1>
                    <p class="text-sm sm:text-base font-light leading-snug">
                        Odkrywaj niesamowite przedmioty i spróbuj zebrać je wszystkie!
                    </p>
                </div>
            </div>
            <div class="relative m-6 p-6 sm:p-8 rounded-lg min-h-64 shadow-2xl overflow-hidden flex flex-col justify-center">
                <div class="absolute inset-0 bg-three bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center">
                    <h1 class="text-xl sm:text-2xl font-bold mb-2">Rozmawiaj z innymi</h1>
                    <p class="text-sm sm:text-base font-light leading-snug">
                        Poznawaj i twórz przyjaźnie na wiele lat podczas swojej przygody.
                    </p>
                </div>
            </div>
            <div class="relative m-6 p-6 sm:p-8 rounded-lg min-h-64 shadow-2xl overflow-hidden flex flex-col justify-center">
                <div class="absolute inset-0 bg-four bg-cover bg-center before:absolute before:inset-0 before:bg-black/50 before:backdrop-blur-sm"></div>
                <div class="relative z-10 text-white text-center">
                    <h1 class="text-xl sm:text-2xl font-bold mb-2">Leveluj do granic możliwości</h1>
                    <p class="text-sm sm:text-base font-light leading-snug">
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