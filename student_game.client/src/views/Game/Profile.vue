<template>
    <h1 class="flex justify-center text-5xl font-bold text-center p-8 gap-4">Profil 
        <span class="block bg-gradient-to-r from-violet-600 to-indigo-600 bg-clip-text text-transparent underline"> {{ profile.nickname }}</span>
    </h1>

    <div id="wrapper" class="grid grid-cols-12 gap-8 p-8 text-slate-200">
        <div class="col-span-12 md:col-span-4">
            <div class="card relative h-28 rounded-xl p-4 shop_background shadow-2xl">
                <span class="text-sm font-medium leading-none"> healthPoints </span>
                <p class="text-center text-3xl font-bold mdi mdi-heart-outline"> {{ profile.healthPoints }} HP / 300 HP</p>
            </div>
        </div>

        <div class="col-span-12 md:col-span-4 text-slate-200">
            <div class="card relative h-28 rounded-xl p-4 shop_background shadow-2xl">
                <span class="text-sm font-medium leading-none"> attackPoints </span>
                <div class="text-center text-2xl font-bold text-h5 mdi mdi-sword"> {{ profile.attackPoints }} ATK / 200 ATK</div>
            </div>
        </div>

        <div class="col-span-12 md:col-span-4 text-slate-200">
            <div class="card relative h-28 rounded-xl p-4 shop_background shadow-2xl">
                <span class="text-sm font-medium leading-none"> defensePoints </span>
                <div class="text-center text-2xl font-bold text-h5 mdi mdi-shield-outline"> {{ profile.defensePoints }} DEF/ 100 DEF</div>
            </div>
        </div>
        <div id="eq" class="col-span-12 md:col-span-8 shop_background rounded-xl shadow-2xl p-8 ">
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
                    <ul v-if="userWeapon.id != 0">
                        <li>{{ userWeapon.name }}</li>
                        <li>{{ userWeapon.damage }}</li>
                        <li>{{ userWeapon.hitChance }}</li>
                        <li>{{ userWeapon.rarity }}</li>
                    </ul>
                    <h2 v-if="userWeapon.id == 0">Brak założonej broni</h2>
                </div>
                <div id="armour" class="border-4 border-[#424242]">
                    <h2 class="text-slate-200">Zbroja</h2>
                    <img src="/chestplate.jpg" alt="chestplate">
                    <ul v-if="userArmour.id != 0">
                        <li>{{ userArmour.name }}</li>
                        <li>{{ userArmour.defense }} DEF</li>
                        <li>{{ userArmour.rarity }}</li>
                    </ul>
                    <h2 v-if="userArmour.id == 0">Brak założonej broni</h2>
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
            <div id="minor info" class="card p-0 text-center">
                <ul>
                    <li  class="bg-[#424242]">{{ profile.healthPoints }} HP 
                        <button class="">+</button> <button>-</button>
                    </li>
                    <li>{{ profile.attackPoints }} ATK </li>
                    <li  class="bg-[#424242]">{{ profile.defensePoints }} DEF </li>
                    <li>{{ profile.luckPoints}} luck </li>
                    <li  class="bg-[#424242]">{{ profile.intelligencePoints }} int </li>
                    <li>{{ profile.levelPoints }} lvl points</li>
                    <li  class="bg-[#424242]">{{ profile.level }} level</li>
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
</style>

<script>
import axios from 'axios';
const studentId = 1;
export default {    
    data() {
        return {
            studentItem: {
                "studentID": studentId,
                "itemID": 0
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
        }
    }
};
</script>