<template>
    <h1 class="text-3xl font-bold text-center mb-8">Profile</h1>
    <v-container fluid class="p-6">
    <!-- Top Row -->
    <v-row class="justify-start space-x-4 mb-6">
        <v-col cols="3" class="border border-white rounded-lg p-4 bg-white shadow-md">
            <!-- Player Info Box 1 -->
            <div class="text-center font-bold text-h5 mdi mdi-heart-outline">{{ profile.healthPoints }} HP</div>
        </v-col>
        <v-col cols="3" class="border border-white rounded-lg p-4 bg-white shadow-md">
            <!-- Player Info Box 2 -->
            <div class="text-center font-bold text-h5 mdi mdi-sword"> {{ profile.attackPoints }} ATK</div>
        </v-col>
        <v-col cols="3" class="border border-white rounded-lg p-4 bg-white shadow-md">
            <!-- Player Info Box 3 -->
            <div class="text-center font-bold text-h5 mdi mdi-shield-outline"> {{ profile.defensePoints }} DEF</div>
        </v-col>
    </v-row>

    <!-- Middle Row - Large Box -->
    <v-row class="justify-start mb-4">
        <v-col cols="9" class="border border-white rounded-lg p-6 bg-white">
            <!-- Main Player Data Section -->
            <div class="text-center">
                <li v-for="item in equipment.armors">
                    {{ item.name }}, {{ item.defense }}, {{ item.cost }}, {{ item.rarity }}, {{ item.quantity }}
                </li>
                <br/>
                <li v-for="item in equipment.foods">
                    {{ item.name }}, {{ item.boostType }}, {{ item.boostAmount }}, {{ item.duration }}, {{ item.cost }}, {{ item.rarity }}, {{ item.quantity }}
                </li>
                <br/>
                <li v-for="item in equipment.weapons">
                    {{ item.name }}, {{ item.damage }}, {{ item.hitChance }}, {{ item.cost }}, {{ item.rarity }}, {{ item.quantity }}
                </li>
            </div>
        </v-col>

    <!-- Right Column -->
        <v-col cols="3" class="space-y-4">
            <div class="border border-white rounded-lg p-6 bg-white">
            <!-- Nazwa, informacje ogólne -->
            
            <div class="text-center">
                {{ profile.nickname }} <br/>
                {{ profile.money }} money, <br/>
                {{ profile.energy }} energy, <br/>
                {{ profile.rank }} rank, <br/>
                {{ profile.level}} lvl, <br/>
                
            </div>
            
            </div>
            <div class="border border-white rounded-lg p-6 bg-white">
            <!-- Statystyki -->
            
            <div class="text-center">
                {{ profile.experience }} exp <br/>
                {{ profile.healthPoints }} hp<br/>
                {{ profile.attackPoints }} atk<br/>
                {{ profile.defensePoints }} def<br/>
                {{ profile.luckPoints }} luck<br/>
                {{ profile.intelligencePoints }} int<br/>
            </div>
            
            </div>
        </v-col>
    </v-row>
    
    </v-container>
</template>

<script>
import axios from 'axios';

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
            const studentId = 1;
            const profilResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentProfile${studentId}`);
            
            if (profilResponse.data.value.success) {
                this.profile = profilResponse.data.value.data;
            } else {
                console.error("Failed to fetch profile: ", profilResponse.data.value.message);
            }
        } catch (error) {
            console.error("Error fetching profile: ", error);
        }
        }
    }
};
</script>
