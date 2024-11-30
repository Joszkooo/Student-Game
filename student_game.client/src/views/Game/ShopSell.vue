<template>
    <div class="min-h-screen  p-4">
        <h1 class="text-5xl font-bold text-center mb-8">Shop</h1>
        <h2 class="text-5xl font-bold text-center mb-8 text-yellow">{{ profile.money }} gold</h2>
        
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
                    <p class="font-medium text-gray-800">{{ weapon.name }} x {{ weapon.quantity }}</p>
                    <p class="text-sm text-red">Attack: {{ weapon.damage }}</p>
                    <p class="text-sm text-green">Price: {{ Math.floor(weapon.cost / 2) }} gold</p>
                </div>
                <button 
                class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                @click="sellItem(weapon , 'weapon')"
                >
                    Sell
                </button>
            </div>
        </div>

        <!-- Armor Section -->
        <div class="bg-white rounded-lg shadow-md p-4">
            <h2 class="text-xl font-semibold text-gray-700 mb-4">Armour</h2>
            <div v-for="armour in userArmour" :key="armour.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="font-medium text-gray-800">{{ armour.name }} x {{ armour.quantity }}</p>
                    <p class="text-sm text-red">Defense: {{ armour.defense }}</p>
                    <p class="text-sm text-green">Price: {{ Math.floor(armour.cost / 2) }} gold</p>
                </div>
                <button 
                class="bg-green-500 text-white px-3 py-1 rounded hover:bg-green-600"
                @click="sellItem(armour, 'armour')"
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
                <p class="font-medium text-gray-800">{{ food.name }} x {{ food.quantity }}</p>
                <p class="text-sm text-red">Boost type: {{ food.boostType }}</p>
                <p class="text-sm text-green">Price: {{ Math.floor(food.cost / 2) }} gold</p>
                </div>
                <button 
                class="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600"
                @click="sellItem(food, 'food')"
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
            profile: {
                nickname: 'none',
                money: 0,
                energy: 0,
                rank: 'none',
                level: 0,
                experience: 0,
                levelPoints: 0,
                healthPoints: 0,
                attackPoints: 0,
                defensePoints: 0,
                luckPoints: 0,
                intelligencePoints: 0
            }
        };
    },
    mounted() {
        this.fetchUserFood();
        this.fetchUserArmour();
        this.fetchUserWeapon();
        this.fetchStudentProfile();
    },
    methods: {
        async fetchStudentProfile(){
            try{
                const userResponse  = await axios.get(`http://localhost:5033/api/Student/GetStudentProfile${userId}`);
                if (userResponse.data.value.success) {
                    this.profile = userResponse.data.value.data;
                } else {
                    console.log("Failed to fetch student: ", userResponse.data.value.message);
                }
            }
            catch (error) {
                console.log("Error fetching user: ", error);
            }
        },
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
        async sellItem(item, type)
        {
            let sellResponse;
            try{
                if (type == 'armour'){
                     sellResponse = await axios.post(`http://localhost:5033/Shop/SellArmour?StudentID=${userId}&ItemID=${item.id}`); // TODO: tutaj da sie inaczej
                    this.fetchUserArmour();
                    this.fetchStudentProfile();
                }
                else if( type == 'weapon') {
                    sellResponse = await axios.post(`http://localhost:5033/Shop/SellWeapon?StudentID=${userId}&ItemID=${item.id}`);
                    this.fetchUserWeapon();
                    this.fetchStudentProfile();
                }
                else if (type == 'food') {
                    sellResponse = await axios.post(`http://localhost:5033/Shop/SellFood?StudentID=${userId}&ItemID=${item.id}`);
                    this.fetchUserFood();
                    this.fetchStudentProfile();
                }
                else {
                    console.log("Brak przedmiotu o typie ", type);
                }
                if (sellResponse.data.value.success) {
                    alert(`Sprzedano ${item.name} za ${ Math.floor(item.cost / 2)}`);
                }
            }
            catch(error){
                console.error("Error while buying: ", error);
            }
        },
    }
}
</script>
