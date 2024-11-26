<template>
    <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
        <!-- Weapons Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Weapons</h2>
            <div v-for="weapon in weaponShop" :key="weapon.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="font-medium text-gray-800">{{ weapon.name }}</p>
                    <p class="text-sm text-red">Attack: {{ weapon.damage }}</p>
                    <p class="text-sm text-green">Price: {{ weapon.cost }} gold</p>
                </div>
                <button 
                class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                @click="buyItem(weapon, 'Weapon')"
                >
                    Buy
                </button>
            </div>
        </div>

        <!-- Armor Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Armor</h2>
            <div v-for="armor in armourShop" :key="armor.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="font-medium text-gray-800">{{ armor.name }}</p>
                    <p class="text-sm text-red">Defense: {{ armor.defense }}</p>
                    <p class="text-sm text-green">Price: {{ armor.cost }} gold</p>
                </div>
                <button 
                class="bg-green-500 text-white px-3 py-1 rounded hover:bg-green-600"
                @click="buyItem(armor, 'Armor')"
                >
                    Buy
                </button>
            </div>
        </div>

        <!-- Food Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Food</h2>
            <div v-for="food in foodShop" :key="food.id" class="border-b py-2 flex justify-between items-center">
                <div>
                <p class="font-medium text-gray-800">{{ food.name }}</p>
                <p class="text-sm text-red">Boost type: {{ food.boostType }}</p>
                <p class="text-sm text-green">Price: {{ food.cost }} gold</p>
                </div>
                <button 
                class="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600"
                @click="buyItem(food, 'Food')"
                >
                    Buy
                </button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    setup () {
        

        return {}
    }
}
</script>
