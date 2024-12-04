<template>
    <div class="min-h-screen p-4">
        <h1 class="text-5xl font-bold text-center mb-8 text-slate-200">Sklep</h1>
        <div class="text-5xl font-bold text-center mb-4 flex justify-center gap-4">
            <h2 class=" text-yellow-400">Posiadasz </h2> 
            <span class="block bg-gradient-to-r from-yellow-400 to-amber-700 bg-clip-text text-transparent">{{ profile.money }}</span>
            <h2 class="text-5xl font-bold text-center gap-4 text-amber-700">złota</h2>
        </div>
        
        <div class="flex flex-wrap flex-row items-center justify-center">
            <h1 class="hover:underline cursor-pointer duration-100 hover:text-gray-300 text-3xl font-bold px-10  m-8 bg-white rounded-lg shadow-md "><router-link :to="{ name: 'ShopBuy' }">Kup</router-link></h1>
            <h1 class="hover:underline cursor-pointer duration-100 hover:text-gray-300 text-3xl font-bold px-10  m-8 bg-white rounded-lg shadow-md "><router-link :to="{ name: 'ShopSell' }">Sprzedaj</router-link></h1>
        </div>
        
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6 ">
        <!-- Weapons Section -->
        <div class="shop_background rounded-lg shadow-md p-4 text-slate-200">
            <h2 class="text-2xl font-semibold flex justify-center mb-4">Bronie</h2>
            <div v-for="weapon in weaponShop" :key="weapon.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="text-xl font-medium">{{ weapon.name }}</p>
                    <p class="text-base text-red">Atak: {{ weapon.damage }}</p>
                    <p class="text-base text-green">Koszt: {{ weapon.cost }} złota</p>
                </div>
                <v-btn 
                class="bg-blue-500 text-white px-3 py-1 rounded hover:bg-blue-600"
                @click="buyItem(weapon, 'Weapon')"
                >
                    Buy
                </v-btn>
            </div>
        </div>

        <!-- Armor Section -->
        <div class="shop_background rounded-lg shadow-md p-4 text-slate-200">
            <h2 class="text-2xl flex justify-center font-semibold mb-4">Zbroje</h2>
            <div v-for="armor in armourShop" :key="armor.id" class="border-b py-2 flex justify-between items-center">
                <div>
                    <p class="text-xl font-medium ">{{ armor.name }}</p>
                    <p class="text-base text-red">Obrona: {{ armor.defense }}</p>
                    <p class="text-base text-green">Koszt: {{ armor.cost }} złota</p>
                </div>
                <v-btn 
                class="bg-green-500 text-white px-3 py-1 rounded hover:bg-green-600"
                @click="buyItem(armor, 'Armour')"
                >
                    Buy
                </v-btn>
            </div>
        </div>

        <!-- Food Section -->
        <div class="shop_background rounded-lg shadow-md p-4 text-slate-200">
            <h2 class="text-2xl font-semibold flex justify-center mb-4">Jedzenie</h2>
            <div v-for="food in foodShop" :key="food.id" class="border-b py-2 flex justify-between items-center">
                <div>
                <p class="text-xl font-medium ">{{ food.name }}</p>
                <p class="text-base text-red">Typ ulepszenia: {{ food.boostType }}</p>
                <p class="text-base text-green">Koszt: {{ food.cost }} złota</p>
                </div>
                <v-btn 
                class="bg-red-500 text-white px-3 py-1 rounded hover:bg-red-600"
                @click="buyItem(food, 'Food')"
                >
                    Buy
                </v-btn>
            </div>
        </div>
    </div>
    <v-dialog
        v-model="buySuccess"
        width="auto"
    >
        <v-card
            max-width="400"
            prepend-icon="mdi-check"
            title="Zakupiono pomyślnie!"
        >
            <v-card-text>
                Kupiono <strong> {{ buyResponse[0] }}</strong> za <strong> {{ buyResponse[1] }}</strong> złota.
            </v-card-text>
        <template v-slot:actions>
            <v-btn
                class="ms-auto hover:underline"
                text="Ok"
                @click="buySuccess = false"
            ></v-btn>
        </template>
        </v-card>
    </v-dialog>

    <v-dialog
        v-model="buyFailure"
        width="auto"
    >
        <v-card
            max-width="400"
            prepend-icon="mdi-message-alert-outline"
            text="Brak wystarczającej ilości złota do kupna!"
            title="Za mało gotówki"
        >
        <template v-slot:actions>
            <v-btn
                class="ms-auto hover:underline"
                text="Ok"
                @click="buyFailure = false"
            ></v-btn>
        </template>
        </v-card>
    </v-dialog>

    </div>
</template>

<script>
    import axios from 'axios';
    const userId = 1;

export default {
    data() {
        return {
            buyResponse: [],
            buySuccess: false,
            buyFailure: false,
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
                    this.buySuccess = true;
                    this.buyResponse = [item.name, item.cost];
                    console.log(`Kupiono ${item.name} za ${item.cost}`);
                    this.fetchStudentProfile();
                }
                else 
                {
                    this.buyFailure = true;
                    console.log(`${buyFoodResponse.data.value.message}`);
                }
            }
            catch(error){
                console.error("Error while buying: ", error);
            }
        },
    }
}
</script>
