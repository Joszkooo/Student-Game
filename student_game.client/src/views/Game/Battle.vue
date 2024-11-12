<template>
    <v-row class="items-center justify-between">
    <v-col cols="4" class="flex justify-end">
        <PlayerCard 
            :name="'Julka'" 
            :rank="'Global Elite'" 
            :hp="200" 
            :atk="20" 
            :lvl="5" 
            :def="10" 
            :luck="50" 
            :int="30" 
            :weapon="'Glock-18'" 
            :armour="'Diamond Chestplate'" 
        />
    </v-col>

    <v-col cols="4" class="flex justify-center">
        <v-btn>
            Fight!
        </v-btn>
    </v-col>

    <v-col cols="4" class="flex justify-start">
        <PlayerCard
            :name="'Michał'" 
            :rank="'Silver I'" 
            :hp="150" 
            :atk="50" 
            :lvl="10" 
            :def="20" 
            :luck="30" 
            :int="30" 
            :weapon="'M4A4'" 
            :armour="'Leather Armour'" 
        />
    </v-col>
</v-row>

</template>

<script setup>
    import PlayerCard from '@/components/PlayerCard.vue';
    
</script>