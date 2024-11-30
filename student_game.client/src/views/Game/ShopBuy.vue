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
            <div v-for="weapon in weaponShop" :key="weapon.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="font-medium text-gray-800">{{ weapon.name }}</p>
                    <p class="text-sm text-red">Attack: {{ weapon.damage }}</p>
                    <p class="text-sm text-green">Price: {{ weapon.cost }} gold</p>
                </div>
                <button 
                class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                @click="buyItem(weapon, 'Weapon'), buyAnimation"
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
                @click="buyItem(armor, 'Armour')"
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
        
    </div>
</template>
    
<script>
    import axios from 'axios';
    const userId = 1;

export default {
    data() {
        return {
            foodShop: [],
            armourShop: [],
            weaponShop: [],
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
        this.fetchAllFood();
        this.fetchAllArmour();
        this.fetchAllWeapon();
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
        async fetchAllFood() {
            try{
                const allFoodResponse = await axios.get('http://localhost:5033/api/Food/GetAllFood');
                
                if (allFoodResponse.data.value.success) {
                    this.foodShop = allFoodResponse.data.value.data;
                    console.log(this.foodShop);
                } else {
                    console.error("Failed to fetch food: ", allFoodResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching food: ", error);
            }
        },
        async fetchAllArmour() {
            try{
                const allArmourResponse = await axios.get('http://localhost:5033/api/Armour/GetAllArmour');
                
                if (allArmourResponse.data.value.success) {
                    this.armourShop = allArmourResponse.data.value.data;
                } else {
                    console.error("Failed to fetch armour: ", allArmourResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching armour: ", error);
            }
        },
        async fetchAllWeapon() {
            try{
                const allWeaponResponse = await axios.get('http://localhost:5033/api/Weapon/GetAllWeapon');
                
                if (allWeaponResponse.data.value.success) {
                    this.weaponShop = allWeaponResponse.data.value.data;
                } else {
                    console.error("Failed to fetch weapon: ", allWeaponResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching weapon: ", error);
            }
        },
        async buyItem(item, category)
        {
            try{
                const buyFoodResponse = await axios.post(`http://localhost:5033/Shop/BuyItem?ItemId=${item.id}&StudentId=${userId}&Category=${category}`); // TODO: tutaj da sie inaczej
                if (buyFoodResponse.data.value.success) {
                    alert(`Kupiono ${item.name} za ${item.cost}`);
                    this.fetchStudentProfile();
                }
                else 
                {
                    alert(`${buyFoodResponse.data.value.message}`); // TODO: kupno działa, ale nie kiedy nie masz gotówki
                }
            }
            catch(error){
                console.error("Error while buying: ", error);
            }
        },
    }
}
</script>
