<template>
    <div class="container mx-auto p-8">
        <h1 class="text-3xl font-bold mb-6">Shop</h1>
        
        <v-tabs v-model="activeTab" background-color="primary" dark>
            <v-tab>Weapons</v-tab>
            <v-tab>Armor</v-tab>
            <v-tab>Food</v-tab>
        </v-tabs>

        <v-tabs-items v-model="activeTab">
            <v-tab-item>
                <ItemGrid :items="weapons" @purchase="purchaseItem" />
            </v-tab-item>
            <v-tab-item>
                <ItemGrid :items="armor" @purchase="purchaseItem" />
            </v-tab-item>
            <v-tab-item>
                <ItemGrid :items="food" @purchase="purchaseItem" />
            </v-tab-item>
        </v-tabs-items>
    </div>
</template>
    
<script setup>
    import { ref } from 'vue';
    import ItemGrid from '../../components/ItemGrid.vue';

    const activeTab = ref(0);

    const weapons = ref([
    { id: 1, name: 'Sword', price: 100 },
    { id: 2, name: 'Axe', price: 120 },
    { id: 3, name: 'Bow', price: 150 },
    ]);

    const armor = ref([
    { id: 1, name: 'Shield', price: 200 },
    { id: 2, name: 'Helmet', price: 80 },
    { id: 3, name: 'Chestplate', price: 250 },
    ]);

    const food = ref([
    { id: 1, name: 'Bread', price: 5 },
    { id: 2, name: 'Apple', price: 2 },
    { id: 3, name: 'Stew', price: 10 },
    ]);

    function purchaseItem(item) {
    alert(`Purchased ${item.name} for ${item.price} gold!`);
    }
</script>

<style scoped>
    .container {
    max-width: 700px;
    }
</style>