<template>
    <div>
        <h1>Twoja nazwa</h1>
        
        <div className="grid grid-cols-5 grid-rows-4 gap-4">
            <div class="p-4 bg-white w-full rounded-xl"> {{ profile.healthPoints }} </div>
            <div class="p-4 bg-white w-full rounded-xl"> {{ profile.attackPoints }} </div>
            <div class="p-4 bg-white w-full rounded-xl"> {{ profile.defensePoints }} </div>
            <div className="p-4 bg-white col-span-2 w-full rounded-xl">Nazwa, wygląd, założony ekwipunek jako zdjęcia, ogólny podgląd</div>
            <div className="p-4 bg-white col-span-2 row-span-3 col-start-4 row-start-2 w-full rounded-xl">Statystyki (z możliwośćia lvlowania)</div>
            <div className="p-4 bg-white col-span-3 row-span-3 col-start-1 row-start-2 w-full rounded-xl">Pozostały eq</div>
        </div>

    </div>
</template>

<script setup lang="ts">
    import {ref, onMounted } from 'vue'
    import axios from 'axios'

    const profile = ref({
        id: 0,
        healthPoints: 0,
        attackPoints: 0,
        defensePoints: 0
    })
    onMounted(async () => {
        try {
            const response = await axios.get('http://localhost:5033/api/Student/Profile?id=1')
            profile.value.attackPoints = response.data.value.data.attackPoints
        }catch (error) {
            console.error('Failed to fetch profile data: ', error)
        }
    })
</script>
