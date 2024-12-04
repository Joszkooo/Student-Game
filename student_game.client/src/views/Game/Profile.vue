<template>
    <h1 class="flex justify-center text-5xl font-bold text-center p-8 gap-4">Profil 
        <span class="block bg-gradient-to-r from-violet-600 to-indigo-600 bg-clip-text text-transparent underline"> {{ profile.nickname }}</span>
    </h1>
    
    
    <div id="wrapper" class="grid grid-cols-12 gap-8 p-8 text-xl text-slate-200">
        <div class="col-span-12 md:col-span-4">
            <div class="card relative h-28 rounded-xl p-4 profile_background shadow-2xl ">
                <span class="text-sm font-medium leading-none"> healthPoints </span>
                <p class="text-center font-bold text-h5 mdi mdi-heart-outline"> {{ profile.healthPoints }} HP</p>
            </div>
        </div>
        
        <div class="col-span-12 md:col-span-4">
            <div class="card relative h-28 rounded-xl p-4 profile_background shadow-2xl ">
                <span class="text-sm font-medium leading-none"> attackPoints </span>
                <div class="text-center font-bold text-h5 mdi mdi-sword"> {{ profile.attackPoints }} ATK</div>
            </div>
        </div>
        
        <div class="col-span-12 md:col-span-4 ">
            <div class="card relative h-28 rounded-xl p-4 profile_background shadow-2xl ">
                <span class="text-sm font-medium leading-none "> defensePoints </span>
                <div class="text-center font-bold text-h5 mdi mdi-shield-outline "> {{ profile.defensePoints }} DEF</div>
            </div>
        </div>
        <div id="eq" class="col-span-12 md:col-span-8 profile_background rounded-xl shadow-2xl p-8 ">
            <p class="flex justify-between">Nazwa, Ilosc buffa, Cena, Rzadkość, Ilość</p>
            <div class="card p-5 list-none">
                <li v-for="(item, index) in equipment.armors">
                    <div :style="`background-color: ${bgColors[index%2]}`">
                        {{ item.name }}, {{ item.defense }} DEF, {{ item.cost }}, {{ item.rarity }}, {{ item.quantity }}
                    </div>
                </li>
                <hr class="h-px my-8 bg-gray-500 border-0 dark:bg-gray-700">
                <li v-for="(item, index) in equipment.foods">
                    <div :style="`background-color: ${bgColors[index%2]}`">
                    {{ item.name }}, {{ item.boostType }}, {{ item.boostAmount }}, {{ item.duration }}, {{ item.cost }}, {{ item.rarity }}, {{ item.quantity }}
                    </div>
                </li>
                <hr class="h-px my-8 bg-gray-500 border-0 dark:bg-gray-700">
                <li v-for="(item, index) in equipment.weapons">
                    <div :style="`background-color: ${bgColors[index%2]}`">
                    {{ item.name }}, {{ item.damage }} DMG, {{ item.hitChance }}, {{ item.cost }}, {{ item.rarity }}, {{ item.quantity }}
                    </div>
                </li>
            </div>
        </div>
        <div id="rest" class="col-span-12 md:col-span-4 rounded-xl profile_background shadow-2xl p-8 font-bold flex flex-col justify-around">
            <div class="card p-0 text-center">
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
        background-color: #525252;
    }

</style>

<script>
import axios from 'axios';
const studentId = 1;
export default {
    
    data() {
        return {
            bgColors: ['#424242', '#525252'],
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
                const eqResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentEquipment${studentId}`);
                
                if (eqResponse.data.value.success) {
                    this.equipment = eqResponse.data.value.data;
                } else {
                    console.error("Failed to fetch equipment: ", eqResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching equipment: ", error);
            }
        },
        
        async fetchProfile() {
            try {
                const profilResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentProfile${studentId}`);
                
                if (profilResponse.data.value.success) {
                    this.profile = profilResponse.data.value.data;
                    this.profile.rank = this.profile.rank.replace("_", " ");
                } else {
                    console.error("Failed to fetch profile: ", profilResponse.data.value.message);
                }
            } 
            catch (error) {
                console.error("Error fetching profile: ", error);
            }
        }
    }
};
</script>
