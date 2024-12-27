<template>
    <h1 class="flex justify-center text-5xl font-bold text-center p-8 gap-4">Profil 
        <span class="block bg-gradient-to-r from-violet-600 to-indigo-600 bg-clip-text text-transparent underline"> {{ profile.nickname }}</span>
    </h1>

    <div id="wrapper" class="grid grid-cols-12 gap-8 p-8 text-slate-200">
        <div class="col-span-12 md:col-span-4">
            <div class="card h-28 rounded-xl p-4 shop_background shadow-2xl">
                <div class="flex items-center justify-center gap-4">
                    <v-progress-circular
                        :model-value="profile.healthPoints / 3"
                        :rotate="360"
                        :size="80"
                        :width="15"
                        color="grey-lighten-2"
                        class="flex-shrink-0"
                    >
                        <span class="text-sm font-medium">{{ Math.round(profile.healthPoints / 3) }}%</span>
                    </v-progress-circular>
                    <p class="text-2xl md:text-3xl font-bold flex items-center gap-2">
                        <span class="mdi mdi-heart text-red-500"></span>
                        <span class="whitespace-nowrap ml-5">{{ profile.healthPoints }} / 300 HP</span>
                    </p>
                </div>
            </div>
        </div>

        <div class="col-span-12 md:col-span-4 text-slate-200">
            <div class="card relative h-28 rounded-xl p-4 shop_background shadow-2xl">
                <div class="flex items-center justify-center gap-4">
                    <v-progress-circular
                        :model-value="profile.attackPoints / 2"
                        :rotate="360"
                        :size="80"
                        :width="15"
                        color="grey-lighten-2"
                        class="flex-shrink-0"
                    >
                        <span class="text-sm font-medium">{{ Math.round(profile.attackPoints / 2) }}%</span>
                    </v-progress-circular>
                    <p class="text-2xl md:text-3xl font-bold flex items-center gap-2">
                        <span class="mdi mdi-heart text-red-500"></span>
                        <span class="whitespace-nowrap ml-5">{{ profile.attackPoints }} / 200 ATK</span>
                    </p>
                </div>
            </div>
        </div>

        <div class="col-span-12 md:col-span-4 text-slate-200">
            <div class="card h-28 rounded-xl p-4 shop_background shadow-2xl">
                <div class="flex items-center justify-center gap-4">
                    <v-progress-circular
                        :model-value="profile.defensePoints"
                        :rotate="360"
                        :size="80"
                        :width="15"
                        color="grey-lighten-2"
                        class="flex-shrink-0"
                    >
                        <span class="text-sm font-medium">{{ Math.round(profile.defensePoints) }}%</span>
                    </v-progress-circular>
                    <p class="text-2xl md:text-3xl font-bold flex items-center gap-2">
                        <span class="mdi mdi-heart text-red-500"></span>
                        <span class="whitespace-nowrap ml-5">{{ profile.defensePoints }} / 100 DEF</span>
                    </p>
                </div>
            </div>
        </div>
        
        <div id="eq" class="col-span-12 md:col-span-8 shop_background rounded-xl shadow-2xl p-8 ">
            <span class="text-2xl font-bold flex text-center justify-center">Ekwipunek</span>
            <div class="card p-5">
                <v-table class="bg-[#454343] text-slate-200">
                    <thead>
                        <tr class="bg-[#424242]">
                            <th class="text-left ">
                                Nazwa
                            </th>
                            <th class="text-left">
                                Defense
                            </th>
                            <th class="text-left">
                                Cena
                            </th>
                            <th class="text-left">
                                Rzadkość
                            </th>
                            <th class="text-left">
                                Ilość
                            </th>
                            <th class="text-left">
                                
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr
                            v-for="item in equipment.armors" :key="item.id">
                                <td>{{ item.name }}</td>
                                <td>{{ item.defense }}</td>
                                <td>{{ item.cost }}</td>
                                <td>{{ item.rarity }}</td>
                                <td>{{ item.quantity }}</td>
                                <td class="text-right"> <button @click="equipArmour(item.id)">Załóż</button> </td>
                        </tr>
                    </tbody>
                </v-table>
                <hr class="h-px my-4 bg-gray-500 border-0 dark:bg-gray-700">
                <v-table class="bg-[#454343] text-slate-200">
                    <thead>
                        <tr class="bg-[#424242]">
                            <th class="text-left">
                                Nazwa
                            </th>
                            <th class="text-left">
                                Typ buffa
                            </th>
                            <th class="text-left">
                                Czas trwania
                            </th>
                            <th class="text-left">
                                Cena
                            </th>
                            <th class="text-left">
                                Rzadkość
                            </th>
                            <th class="text-left">
                                Ilość
                            </th>
                            <th class="text-left">
                                
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr
                            v-for="item in equipment.foods">
                                    <td>{{ item.name }}</td>
                                    <td>{{ item.boostType }}</td>
                                    <td>{{ item.duration }}</td>
                                    <td>{{ item.cost }}</td>
                                    <td>{{ item.rarity }}</td>
                                    <td>{{ item.quantity }}</td>
                                    <td class="text-right"></td>
                        </tr>
                        
                    </tbody>
                </v-table>
                <hr class="h-px my-4 bg-gray-500 border-0 dark:bg-gray-700">
                <v-table class="bg-[#454343] text-slate-200"> <!-- <div :style="`background-color: ${bgColors[index%2]}`"> -->
                    <thead>
                        <tr class="bg-[#424242]">
                            <th class="text-left">
                                Nazwa
                            </th>
                            <th class="text-left">
                                Obrażenia
                            </th>
                            <th class="text-left">
                                Trafienie
                            </th>
                            <th class="text-left">
                                Cena
                            </th>
                            <th class="text-left">
                                Rzadkość
                            </th>
                            <th class="text-left">
                                Ilość
                            </th>
                            <th class="text-left">
                                
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr
                            v-for="item in equipment.weapons" :key="item.id">
                                    <td>{{ item.name }}</td>
                                    <td>{{ item.damage }} DMG</td>
                                    <td>{{ item.hitChance }}%</td>
                                    <td>{{ item.cost }}</td>
                                    <td>{{ item.rarity }}</td>
                                    <td>{{ item.quantity }}</td>
                                    <td class="text-right"> <button @click="equipWeapon(item.id)">Załóż</button> </td>
                        </tr>
                    </tbody>
                </v-table>
            </div>
        </div>
        <div id="rest" class="col-span-12 md:col-span-4 rounded-xl shop_background shadow-2xl p-7 font-bold flex flex-col justify-around">
            <div id="equipped" class="grid grid-cols-1 md:grid-cols-2 gap-5">
                <div id="weapon" class="border-4 border-[#424242]">
                    <h2 class="text-slate-200">Broń</h2>
                    <img src="/sword.jpg" alt="sword">
                    <ul v-if="userWeapon.id != 0" class="justify-center text-center">
                        <li>{{ userWeapon.name }}</li>
                        <li>{{ userWeapon.damage }} DMG</li>
                        <li>{{ userWeapon.hitChance }}% na uderzenie</li>
                        <li>{{ userWeapon.rarity }}</li>
                    </ul>
                    <h2 v-if="userWeapon.id == 0">Brak założonej broni</h2>
                </div>
                <div id="armour" class="border-4 border-[#424242]">
                    <h2 class="text-slate-200">Zbroja</h2>
                    <img src="/chestplate.jpg" alt="chestplate">
                    <ul v-if="userArmour.id != 0" class="justify-center text-center">
                        <li>{{ userArmour.name }}</li>
                        <li>{{ userArmour.defense }} DEF</li>
                        <li>{{ userArmour.rarity }}</li>
                    </ul>
                    <h2 v-if="userArmour.id == 0">Brak założonej broni</h2>
                </div>
            </div>
            <div id="minor info" class="card text-center text-xl">
                <ul class="">
                    <li  class="bg-[#424242] border-4 border-black/10 rounded-xl mb-10">{{ profile.rank }},  {{ profile.level}} lvl</li>
                    <li class="border-4 border-black/10 rounded-xl mb-10">{{ profile.experience }}exp / 100exp <button @click="levelUp()" class="ml-8 p-1 bg-white justify-end rounded-lg">LEVEL UP</button> </li>
                    <li  class="bg-[#424242] border-4 border-black/10 rounded-xl mb-10">{{ profile.luckPoints }} szczęścia, {{ profile.intelligencePoints }} inteligencji</li>
                    <li class="border-4 border-black/10 rounded-xl mb-10">{{ profile.levelPoints }} lvl points</li>
                    <li  class="bg-[#424242] border-4 border-black/10 rounded-xl mb-10">W:{{ userStats.victories }}, P: {{ userStats.defeats }}</li>
                    <li class="border-4 border-black/10 rounded-xl mb-10">{{ userStats.fights }} bitw</li>
                </ul>
                <div class="bg-black/10 border border-white/10 rounded-md flex flex-col gap-2 border-t px-4 py-2">
                    <div class="grid grid-cols-5 gap-2">
                        <div class="text-center">
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="increasePoint(0)"
                            >
                                <img class="w-8 aspect-square rotateUp" src="/up-arrow.png" alt="Increase">
                            </div>
                            <p
                            :class="['text-white font-semibold', denyAnimation[0] ? 'deny-animation' : '']"
                            @animationend="resetDeny(0)"
                            >
                            {{ spendingPoints[0] }}
                            </p>
                            <p class="text-white">HP</p>
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="decreasePoint(0)"
                            >
                                <img class="w-8 aspect-square rotateDown" src="/up-arrow.png" alt="Decrease">
                            </div>
                        </div>

                        <div class="text-center">
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="increasePoint(1)"
                            >
                                <img class="w-8 aspect-square rotateUp" src="/up-arrow.png" alt="Increase">
                            </div>
                            <p
                            :class="['text-white font-semibold', denyAnimation[1] ? 'deny-animation' : '']"
                            @animationend="resetDeny(1)"
                            >
                            {{ spendingPoints[1] }}
                            </p>
                            <p class="text-white">ATK</p>
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="decreasePoint(1)"
                            >
                                <img class="w-8 aspect-square rotateDown" src="/up-arrow.png" alt="Decrease">
                            </div>
                        </div>

                        <div class="text-center">
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="increasePoint(2)"
                            >
                                <img class="w-8 aspect-square rotateUp" src="/up-arrow.png" alt="Increase">
                            </div>
                            <p
                            :class="['text-white font-semibold', denyAnimation[2] ? 'deny-animation' : '']"
                            @animationend="resetDeny(2)"
                            >
                            {{ spendingPoints[2] }}
                            </p>
                            <p class="text-white">DEF</p>
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="decreasePoint(2)"
                            >
                                <img class="w-8 aspect-square rotateDown" src="/up-arrow.png" alt="Decrease">
                            </div>
                        </div>
                        <div class="text-center">
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="increasePoint(3)"
                            >
                                <img class="w-8 aspect-square rotateUp" src="/up-arrow.png" alt="Increase">
                            </div>
                            <p
                            :class="['text-white font-semibold', denyAnimation[3] ? 'deny-animation' : '']"
                            @animationend="resetDeny(3)"
                            >
                            {{ spendingPoints[3] }}
                            </p>
                            <p class="text-white">LUCK</p>
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="decreasePoint(3)"
                            >
                                <img class="w-8 aspect-square rotateDown" src="/up-arrow.png" alt="Decrease">
                            </div>
                        </div>
                        <div class="text-center">
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="increasePoint(4)"
                            >
                                <img class="w-8 aspect-square rotateUp" src="/up-arrow.png" alt="Increase">
                            </div>
                            <p
                            :class="['text-white font-semibold', denyAnimation[4] ? 'deny-animation' : '']"
                            @animationend="resetDeny(4)"
                            >
                            {{ spendingPoints[4] }}
                            </p>
                            <p class="text-white">INT</p>
                            <div
                            class="flex items-center justify-center p-2 text-natural-100 border border-white/10 rounded-lg hover:cursor-pointer"
                            @click="decreasePoint(4)"
                            >
                                <img class="w-8 aspect-square rotateDown" src="/up-arrow.png" alt="Decrease">
                            </div>
                        </div>
                    </div>
                    <span class="flex justify-center items-center text-white font-bold hover:cursor-pointer" @click="spendPoints">{{ profile.levelPoints }} level points</span>
                </div>

            </div>
        </div>
    </div>


    <v-dialog
        v-model="levelSuccess"
        width="auto"
    >
        <v-card
            max-width="400"
            prepend-icon="mdi-check"
            title="Nowy poziom!"
        >
            <v-card-text>
                Levelowałeś na <strong> {{ levelResponse.level }} lvl</strong> i <strong> masz {{ levelResponse.experience }}</strong> exp'a.
                Twoja ranga to <strong>{{ levelResponse.rank }}</strong>
            </v-card-text>
        <template v-slot:actions>
            <v-btn
                class="ms-auto hover:underline"
                text="Ok"
                @click="levelSuccess = false"
            ></v-btn>
        </template>
        </v-card>
    </v-dialog>

    <v-dialog
        v-model="levelFailure"
        width="auto"
    >
        <v-card
            max-width="400"
            prepend-icon="mdi-message-alert-outline"
            text="Brak wystarczającej ilości exp'a do nowego poziomu lub maksymalny poziom osiągnięty!"
            title="Za mało exp'a"
        >
        <template v-slot:actions>
            <v-btn
                class="ms-auto hover:underline"
                text="Ok"
                @click="levelFailure = false"
            ></v-btn>
        </template>
        </v-card>
    </v-dialog>

</template>

<style>
    .card{
        padding: 16px;
        box-sizing: border-box;
        margin-bottom: 16px;
    }
    .rotateUp {
    -webkit-transform: rotate(-90deg);
    -moz-transform: rotate(-90deg);
    -o-transform: rotate(-90deg);
    -ms-transform: rotate(-90deg);
    transform: rotate(-90deg);
    }
    .rotateDown {
    -webkit-transform: rotate(90deg);
    -moz-transform: rotate(90deg);
    -o-transform: rotate(90deg);
    -ms-transform: rotate(90deg);
    transform: rotate(90deg);
    }

    .deny-animation {
    animation: shake 0.5s ease;
    }

    @keyframes shake {
    0%, 100% {
        transform: translateX(0);
    }
    25% {
        transform: translateX(-5px);
    }
    50% {
        transform: translateX(5px);
    }
    75% {
        transform: translateX(-5px);
    }
    }
</style>

<script>
import axios from 'axios';
const studentId = 1;
export default {    
    data() {
        return {
            spendingPoints: [0, 0, 0, 0, 0],
            denyAnimation: [false, false, false, false, false],
            pointsData: {
                id: 0,
                healthPoints: 0,
                attackPoints: 0,
                defensePoints: 0,
                luckPoints: 0,
                intelligencePoints: 0
            },
            levelResponse: {
                id: 0,
                levelPoints: 0,
                level: 0,
                experience: 0,
                rank: "null"
            },
            pointsModal: false,
            levelSuccess: false,
            levelFailure: false,
            studentItem: {
                "studentID": studentId,
                "itemID": 0
            },
            userStats: {
                id: 0,
                nickname: "none",
                fights: 0,
                victories: 0,
                defeats: 0
            },
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
                intelligencePoints: 0,
                weaponId: null,
                armourId: null
            },
            equipment: {
                armors: {
                    id: 0,
                    name: 'none',
                    defense: 0,
                    cost: 0,
                    rarity: 'none',
                    quantity: 0
                },
                foods:{
                    id: 0,
                    name: 'none',
                    boostType: 'none',
                    boostAmount: 0,
                    duration: 0,
                    cost: 0,
                    rarity: 'none',
                    quantity: 0
                },
                weapons: {
                    id: 0,
                    name: 'none',
                    damage: 0,
                    hitChance: 0,
                    cost: 0,
                    rarity: 'none',
                    quantity: 0
                }
            },
            userWeapon: {
                id: 0,
                name: null,
                damage: null,
                hitChance: null,
                cost: null,
                rarity: null
            },
            userArmour: {
                id: 0,
                name: null,
                defense: null,
                cost: null,
                rarity: null
            }
        };
    },
    mounted() {
        this.fetchProfile();
        this.fetchEquipment();
        this.fetchStats();
    },
    methods: {
        increasePoint(index){
            if(this.spendingPoints[index] >= 0 ){
                this.spendingPoints[index]++;
            }
        },
        decreasePoint(index){
            if(this.spendingPoints[index] > 0 ){
                this.spendingPoints[index]--;
            }else {
                this.triggerDeny(index);
            }
        },
        triggerDeny(index) {
            this.denyAnimation[index] = true; // Start the deny animation
        },
        resetDeny(index) {
            this.denyAnimation[index] = false; // Reset animation state after it ends
        },
        async fetchEquipment() {
            try{
                const studentId = 1;
                const eqResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentEquipment${studentId}`);
                
                if (eqResponse.data.value.success) {
                    this.equipment = eqResponse.data.value.data;
                } else {
                    console.error("Failed to fetch equipment: ", eqResponse.data.value.message);
                }
            }catch (error) {
            console.error("Error fetching equipment: ", error);
        }
        },
        async fetchProfile() {
            try {
                const profilResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentProfile${studentId}`);
                
                if (profilResponse.data.value.success) {
                    this.profile = profilResponse.data.value.data;
                    
                    this.profile.rank = this.profile.rank.replace("_", " ");
                    
                    if (this.profile.armourId){
                        this.fetchArmour();
                    }
                    if (this.profile.weaponId){
                        this.fetchWeapon();
                    }
                } else {
                    console.error("Failed to fetch profile: ", profilResponse.data.value.message);
                }
            } 
            catch (error) {
                console.error("Error fetching profile: ", error);
            }
        },
        async fetchWeapon() {
            try{
                const weaponResponse = await axios.get(`http://localhost:5033/api/Weapon/${this.profile.weaponId}`);
                
                if (weaponResponse.data.value.success) {
                    this.userWeapon = weaponResponse.data.value.data;
                }else {
                    console.error("Failed to fetch user weapon: ", weaponResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching weapon: ", error);
            }
        },
        async fetchArmour() {
            try{
                const armourResponse = await axios.get(`http://localhost:5033/api/Armour/${this.profile.armourId}`);
                
                if (armourResponse.data.value.success) {
                    this.userArmour = armourResponse.data.value.data;
                }else {
                    console.error("Failed to fetch user armour: ", armourResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching armour: ", error);
            }
        },
        async equipWeapon(itemID){
            this.studentItem.itemID = itemID;
            const equipWeaponResponse = await axios.post(`http://localhost:5033/api/Equipment/EquipWeapon`, this.studentItem);
            if(equipWeaponResponse.data.value.success){
                console.log(equipWeaponResponse.data.value.message);

                this.fetchProfile();
                this.fetchEquipment();
                this.fetchWeapon();
            }else{
                console.error("Error fetching equipWeapon: ", equipWeaponResponse.data.value.message);
            }
        },
        async equipArmour(itemID){
            this.studentItem.itemID = itemID;
            const equipArmourResponse = await axios.post(`http://localhost:5033/api/Equipment/EquipArmour`, this.studentItem);
            if(equipArmourResponse.data.value.success){
                console.log(equipArmourResponse.data.value.message);
                this.fetchProfile();
                this.fetchEquipment();
                this.fetchArmour();
            }else{
                console.error("Error fetching equipArmour: ", equipArmourResponse.data.value.message);
            }
        },
        async fetchStats(){
            try{
                const userStatsResponse = await axios.get(`http://localhost:5033/api/Stat/${studentId}`);
            if(userStatsResponse.data.value.success){
                this.userStats = userStatsResponse.data.value.data;
            }
            else {
                    console.error("Failed to fetch user stats: ", userStatsResponse.data.value.message);
                }
            } catch (error) {
                console.error("Error fetching stats: ", error);
            }
        },
        async levelUp(){
            try {
                const levelUpResponse = await axios.patch(`http://localhost:5033/api/Level/CheckLvlUp${studentId}`);
                if(levelUpResponse.data.value.success){
                    this.levelResponse = levelUpResponse.data.value.data;
                    this.levelSuccess = true;
                    this.fetchProfile();
                }else {
                    this.levelFailure = true;
                    console.error("Failed to fetch level: ", levelUpResponse.data.value.message);
                }
            } catch (error) {
                console.error("Error fetching level: ", error);
            }
        },
        async spendPoints(){
            try {
                const spendPointsResponse = await axios.patch(`http://localhost:5033/api/Level/IncrementLvlPoints${studentId}`, this.spendingPoints);
                if(spendPointsResponse.data.value.success){
                    this.pointsData = spendPointsResponse.data.value.data;
                    this.fetchProfile();
                }else {
                    console.error("Failed to fetch points: ", spendPointsResponse.data.value.message);
                }
            } catch (error) {
                console.error("Error fetching points: ", error);
            }
        }
    }
};
</script>