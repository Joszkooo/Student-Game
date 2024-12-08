<template>
    <h1 class="text-3xl font-bold text-center p-8">Profile</h1>
    
    <div id="wrapper" class="grid grid-cols-12 gap-8 p-8">
        <div class="col-span-12 md:col-span-4">
            <div class="card relative h-28 rounded-xl p-4 profile_background shadow-2xl">
                <span class="text-sm font-medium leading-none"> healthPoints </span>
                <p class="text-center font-bold text-h5 mdi mdi-heart-outline"> {{ profile.healthPoints }} HP</p>
            </div>
        </div>
        
        <div class="col-span-12 md:col-span-4">
            <div class="card relative h-28 rounded-xl p-4 profile_background shadow-2xl">
                <span class="text-sm font-medium leading-none"> attackPoints </span>
                <div class="text-center font-bold text-h5 mdi mdi-sword"> {{ profile.attackPoints }} ATK</div>
            </div>
        </div>
        
        <div class="col-span-12 md:col-span-4 ">
            <div class="card relative h-28 rounded-xl p-4 profile_background shadow-2xl">
                <span class="text-sm font-medium leading-none"> defensePoints </span>
                <div class="text-center font-bold text-h5 mdi mdi-shield-outline"> {{ profile.defensePoints }} DEF</div>
            </div>
        </div>
        <div id="eq" class="col-span-12 md:col-span-8 profile_background rounded-xl shadow-2xl p-8 ">
            <div class="card p-5">
                <v-table class="profile_background text-slate-200">
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
                            v-for="item in equipment.armors">
                            <!-- <div :style="`background-color: ${bgColors[index%2]} -->
                                <td>{{ item.name }}</td>
                                <td>{{ item.defense }}</td>
                                <td>{{ item.cost }}</td>
                                <td>{{ item.rarity }}</td>
                                <td>{{ item.quantity }}</td>
                                <td class="text-right"> <button>Załóż</button> </td>
                        </tr>
                    </tbody>
                </v-table>
                <hr class="h-px my-4 bg-gray-500 border-0 dark:bg-gray-700">
                <v-table class="profile_background text-slate-200">
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
                            v-for="(item, index) in equipment.foods">
                                    <td>{{ item.name }}</td>
                                    <td>{{ item.boostType }}</td>
                                    <td>{{ item.duration }}</td>
                                    <td>{{ item.cost }}</td>
                                    <td>{{ item.rarity }}</td>
                                    <td>{{ item.quantity }}</td>
                                    <td class="text-right"> <button>Załóż</button> </td>
                        </tr>
                        
                    </tbody>
                </v-table>
                <hr class="h-px my-4 bg-gray-500 border-0 dark:bg-gray-700">
                <v-table class="profile_background text-slate-200"> <!-- <div :style="`background-color: ${bgColors[index%2]}`"> -->
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
                            v-for="item in equipment.weapons">
                                    <td>{{ item.name }}</td>
                                    <td>{{ item.damage }} DMG</td>
                                    <td>{{ item.hitChance }}%</td>
                                    <td>{{ item.cost }}</td>
                                    <td>{{ item.rarity }}</td>
                                    <td>{{ item.quantity }}</td>
                                    <td class="text-right"> <button>Załóż</button> </td>
                        </tr>
                    </tbody>
                </v-table>
            </div>
        </div>
        <div id="rest" class="col-span-12 md:col-span-4 rounded-xl profile_background shadow-2xl p-7 font-bold flex flex-col justify-around">
            <div id="equipped" class="grid grid-cols-1 md:grid-cols-2 gap-5">
                <div id="weapon" class="border-4 border-[#424242]">
                    <h2 class="text-black">Broń</h2>
                    <img src="/sword.jpg" alt="sword">
                    <ul>
                        <li>{{ userWeapon.name }}</li>
                        <li>{{ userWeapon.damage }}</li>
                        <li>{{ userWeapon.hitChance }}</li>
                        <li>{{ userWeapon.rarity }}</li>
                    </ul>
                    <v-btn class="text-black rounded bg-white" id="takeOff">Sciągnij</v-btn>
                </div>
                <div id="armour" class="border-4 border-[#424242]">
                    <h2 class="text-black">Zbroja</h2>
                    <img src="/chestplate.jpg" alt="chestplate">
                    <ul>
                        <li>{{ userArmour.name }}</li>
                        <li>{{ userArmour.defense }} DEF</li>
                        <li>{{ userArmour.rarity }}</li>
                    </ul>
                    <v-btn class="text-black rounded bg-white" id="takeOff">Sciągnij</v-btn>
                </div>
            </div>
            <div id="minor info" class="card p-0 text-center">
                <ul>
                    <li  class="bg-[#424242]">{{ profile.money }} $ </li>
                    <li>{{ profile.energy }} energy </li>
                    <li  class="bg-[#424242]">{{ profile.rank }} rank </li>
                    <li>{{ profile.level}} lvl </li>
                    <li  class="bg-[#424242]">{{ profile.experience }} exp </li>
                    <li>{{ profile.luckPoints }} luck</li>
                    <li  class="bg-[#424242]">{{ profile.intelligencePoints }} int</li>
                </ul>
            </div>
        </div>
    </div>
    
</template>

<style>
    .card{
        padding: 16px;
        box-sizing: border-box;
        margin-bottom: 16px;
    }
    .profile_background{
        background-color: #454343;
        /* background-color: #636363; */
    }
</style>

<script>
import axios from 'axios';
const studentId = 1;

export default {    
    data() {
        return {
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
                id: null,
                name: null,
                damage: null,
                hitChance: null,
                cost: null,
                rarity: null
            },
            userArmour: {
                id: null,
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
    },
    methods: {
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
        }
    }
};
</script>
