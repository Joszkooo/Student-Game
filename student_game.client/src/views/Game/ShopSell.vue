<template>
    <div class="min-h-screen  p-4">
        <h1 class="text-5xl font-bold text-center mb-8">Shop</h1>
        
        <div class="flex flex-wrap flex-row items-center justify-center">
            <h1 class="hover:underline cursor-pointer duration-100 hover:text-gray-300 text-3xl font-bold px-10  m-8 bg-white rounded-lg shadow-md "><router-link :to="{ name: 'ShopBuy' }">Buy</router-link></h1>
            <h1 class="hover:underline cursor-pointer duration-100 hover:text-gray-300 text-3xl font-bold px-10  m-8 bg-white rounded-lg shadow-md "><router-link :to="{ name: 'ShopSell' }">Sell</router-link></h1>
        </div>
        
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
        <!-- Weapons Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Weapons</h2>
            <div v-for="weapon in userWeapon" :key="weapon.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="font-medium text-gray-800">{{ weapon.name }}</p>
                    <p class="text-sm text-red">Attack: {{ weapon.damage }}</p>
                    <p class="text-sm text-green">Price: {{ weapon.cost }} gold</p>
                </div>
                <button 
                class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                @click="sellItem(weapon)"
                >
                    Sell
                </button>
            </div>
        </div>

        <!-- Armor Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Armor</h2>
            <div v-for="armor in userArmour" :key="armor.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="font-medium text-gray-800">{{ armor.name }}</p>
                    <p class="text-sm text-red">Defense: {{ armor.defense }}</p>
                    <p class="text-sm text-green">Price: {{ armor.cost }} gold</p>
                </div>
                <button 
                class="bg-green-500 text-white px-3 py-1 rounded hover:bg-green-600"
                @click="sellItem(armor)"
                >
                    Sell
                </button>
            </div>
        </div>

        <!-- Food Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Food</h2>
            <div v-for="food in userFood" :key="food.id" class="border-b py-2 flex justify-between items-center">
                <div>
                <p class="font-medium text-gray-800">{{ food.name }}</p>
                <p class="text-sm text-red">Boost type: {{ food.boostType }}</p>
                <p class="text-sm text-green">Price: {{ food.cost }} gold</p>
                </div>
                <button 
                class="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600"
                @click="sellItem(food)"
                >
                    Sell
                </button>
            </div>
        </div>
    </div>
        
    </div>
</template>
    
<script>
    import axios from 'axios';

    const userId = 1;
export default {
    
    data() {
        return {
            userFood: [],
            userArmour: [],
            userWeapon: [],
        };
    },
    mounted() {
        this.fetchUserFood();
        this.fetchUserArmour();
        this.fetchUserWeapon();
    },
    methods: {
        async fetchUserFood() {
            try{
                const userFoodResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentFood${userId}`);
                
                if (userFoodResponse.data.value.success) {
                    this.userFood = userFoodResponse.data.value.data;
                    console.log(this.userFood);
                } else {
                    console.error("Failed to fetch food: ", userFoodResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching food: ", error);
            }
        },
        async fetchUserArmour() {
            try{
                const userArmourResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentArmour${userId}`);
                
                if (userArmourResponse.data.value.success) {
                    this.userArmour = userArmourResponse.data.value.data;
                } else {
                    console.error("Failed to fetch armour: ", userArmourResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching armour: ", error);
            }
        },
        async fetchUserWeapon() {
            try{
                const userWeaponResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentWeapon${userId}`);
                
                if (userWeaponResponse.data.value.success) {
                    this.userWeapon = userWeaponResponse.data.value.data;
                } else {
                    console.error("Failed to fetch weapon: ", userWeaponResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching weapon: ", error);
            }
        },
        async sellItem(item)
        {
            try{
                const buyFoodResponse = await axios.post(`http://localhost:5033/Shop/SellArmour?StudentID=${userId}&ItemID=${item.id}`); // TODO: tutaj da sie inaczej
                if (buyFoodResponse.data.value.success) {
                    alert(`Sprzedano ${item.name} za ${item.cost}`);
                }
            }
            catch(error){
                console.error("Error while buying: ", error);
            }
        },
    }
}
</script>
