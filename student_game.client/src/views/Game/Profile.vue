<template>
    <h1 class="flex justify-center text-5xl font-bold text-center p-8 gap-4">Profil 
        <span class="block bg-gradient-to-r from-violet-600 to-indigo-600 bg-clip-text text-transparent underline"> {{ profile.nickname }}</span>
    </h1>

    <div id="wrapper" class="grid grid-cols-12 gap-8 p-8 text-slate-200">
        <StatCard
            :value="profile.healthPoints"
            :maxValue="300"
            label="HP"
            iconClass="mdi mdi-heart text-red-500"
        />
        <StatCard
            :value="profile.attackPoints"
            :maxValue="200"
            label="ATK"
            iconClass="mdi mdi-sword text-yellow-500"
        />
        <StatCard
            :value="profile.defensePoints"
            :maxValue="100"
            label="DEF"
            iconClass="mdi mdi-shield text-blue-500"
        />
        
        <EquipmentTable
            :equipment="equipment"
            :equipArmour="equipArmour"
            :equipWeapon="equipWeapon"
        />
        
        <div id="rest" class="col-span-12 md:col-span-4 rounded-xl shop_background shadow-2xl p-7 font-bold flex flex-col justify-around">
            <div id="equipped" class="grid grid-cols-1 md:grid-cols-2 gap-5">
                <div id="weapon" class="border-4 border-[#424242]">
                    <h2 class="text-slate-200">Broń</h2>
                    <img src="/sword.jpg" alt="sword">
                    <ul v-if="wearingWeapon.id != 0" class="justify-center text-center">
                        <li>{{ wearingWeapon.name }}</li>
                        <li>{{ wearingWeapon.damage }} DMG | {{ wearingWeapon.hitChance }}% na uderzenie</li>
                        <li>{{ wearingWeapon.rarity }}</li>
                    </ul>
                    <h2 v-if="wearingWeapon.id == 0">Brak założonej broni</h2>
                </div>
                <div id="armour" class="border-4 border-[#424242]">
                    <h2 class="text-slate-200">Zbroja</h2>
                    <img src="/chestplate.jpg" alt="chestplate">
                    <ul v-if="wearingArmour.id != 0" class="justify-center text-center">
                        <li>{{ wearingArmour.name }}</li>
                        <li>{{ wearingArmour.defense }} DEF</li>
                        <li>{{ wearingArmour.rarity }}</li>
                    </ul>
                    <h2 v-if="wearingArmour.id == 0">Brak założonej broni</h2>
                </div>
            </div>
            <div id="minor info" class="card text-center text-xl">
                <ul class="">
                    <li  class="bg-[#424242] border-4 border-black/10 rounded-xl mb-10">{{ profile.rank }},  {{ profile.level}} lvl</li>
                    <li class="border-4 border-black/10 rounded-xl mb-10">{{ profile.experience }}exp / 100exp <button @click="levelUp()" class="ml-8 p-1 bg-white justify-end rounded-lg">LEVEL UP</button> </li>
                    <li  class="bg-[#424242] border-4 border-black/10 rounded-xl mb-10">{{ profile.luckPoints }} szczęścia, {{ profile.intelligencePoints }} inteligencji</li>
                    <li class="border-4 border-black/10 rounded-xl mb-10">{{ profile.levelPoints }} lvl points</li>
                    <li  class="bg-[#424242] border-4 border-black/10 rounded-xl mb-10">W:{{ userStats.victories }}, P: {{ userStats.defeats }}</li>
                    <li class="border-4 border-black/10 rounded-xl mb-10">{{ userStats.fights }} bitew</li>
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

<script>
import axios from 'axios';
import StatCard from '@/components/Profile/StatCard.vue';
import EquipmentTable from '@/components/Profile/EquipmentTable.vue';

const studentId = 3;
export default {    
    components: {
        StatCard,
        EquipmentTable
    },
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
            wearingWeapon: {
                id: 0,
                name: null,
                damage: null,
                hitChance: null,
                cost: null,
                rarity: null
            },
            wearingArmour: {
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
                    this.wearingWeapon = weaponResponse.data.value.data;
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
                    this.wearingArmour = armourResponse.data.value.data;
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