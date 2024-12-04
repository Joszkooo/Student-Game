<template>
    <div id="wrapper" class="min-h-screen p-5">
        <div id="choose" class="p-10 grid grid-cols-1 md:grid-cols-3 gap-6">
            <div id="first" class="bg-white p-5">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyOne.name }}</h1>
                <img src="/Goblin.jpg" />
                <PlayerCard 
                    :attackPoints="enemyOne.attackPoints"
                    :level="enemyOne.level"
                    :defensePoints="enemyOne.defensePoints"
                    :luckPoints="enemyOne.luckPoints"
                    :rank = "enemyOne.rank"
                ></PlayerCard>
                {{ enemyOne.id }}
            </div>
            <div id="second" class="bg-white p-5">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyTwo.name }}</h1>
                <img src="/Orc.jpg" />
                <PlayerCard 
                    :attackPoints="enemyTwo.attackPoints"
                    :level="enemyTwo.level"
                    :defensePoints="enemyTwo.defensePoints"
                    :luckPoints="enemyTwo.luckPoints"
                    :rank = "enemyTwo.rank"
                ></PlayerCard>
                {{ enemyTwo.id }}
            </div>
            <div id="third" class="bg-white p-5">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyThree.name }}</h1>
                <img src="/Troll.jpg" />
                <PlayerCard 
                    :attackPoints="enemyThree.attackPoints"
                    :level="enemyThree.level"
                    :defensePoints="enemyThree.defensePoints"
                    :luckPoints="enemyThree.luckPoints"
                    :rank = "enemyThree.rank"
                ></PlayerCard>
                {{ enemyThree.id }}
            </div>
        </div>
        <div id="fight" class="p-10 grid grid-cols-1 md:grid-cols-3 gap-6">
            <div id="student" class="bg-white p-5">
                <img src="/Player.jpg" />
                <PlayerCard
                    :attackPoints="profile.attackPoints"
                    :level="profile.level"
                    :defensePoints="profile.defensePoints"
                    :luckPoints="profile.luckPoints",
                    :rank="profile.rank"
                ></PlayerCard>
            </div>
            <button @click=";fightEnd = true" class="bg-white">
                FIGHT!
            </button>
            <div id="enemy" class="bg-white p-5">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyThree.name }}</h1>
                <img src="/Zombie.jpg" />
                <PlayerCard
                    :attackPoints="enemyOne.attackPoints"
                    :level="enemyOne.level"
                    :defensePoints="enemyOne.defensePoints"
                    :luckPoints="enemyOne.luckPoints",
                    :rank="enemyOne.rank"
                ></PlayerCard>
            </div>
        </div>
    </div>
    <v-dialog
        v-model="fightEnd"
        width="auto"
    >
        <v-card
            min-width="1000"
            min-height="500"
            prepend-icon="mdi-sword"
            title="Wygrana/Przegrana!"
            class="text-center"
        >
        <v-card-text class="text-center">
            <p>WinnerGold: {{ fightData.winnerGold }}</p>
            <p>WinnerExp: {{ fightData.winnerExp }}</p>
            <p>LooserGold: {{ fightData.looserGold }}</p>
            <p>LooserExp: {{ fightData.looserExp }}</p>
        </v-card-text>
        <template v-slot:actions>
            <v-btn
                class="ms-auto hover:underline"
                text="Ok"
                @click="fightEnd = false"
            ></v-btn>
        </template>
        </v-card>
    </v-dialog>
</template>

<script lang="ts">
import PlayerCard from "@/components/PlayerCard.vue";
import axios from "axios";
import Profile from "./Profile.vue";
const studentId = 1;
export default{
    components: {PlayerCard},
    data() {
        return{
            fightEnd: false,
            characters:{
            "attackerId": studentId,
            },
            enemyPicture: [
                "Goblin.jpg",
                "Orc.jpg",
                "Troll.png",
                "Dragon.png",
                "Skeleton.png",
                "Zombie.png",
                "Vampire.png",
                "Werewolf.png",
                "Demon.png",
                "Witch.png"
            ],
            enemyOne: {
                id: 0,
                name: "null",
                rank: "null",
                level: 0,
                healthPoints: 0,
                attackPoints: 0,
                defensePoints: 0,
                luckPoints: 0
            },
            enemyTwo: {
                id: 0,
                name: "null",
                rank: "null",
                level: 0,
                healthPoints: 0,
                attackPoints: 0,
                defensePoints: 0,
                luckPoints: 0
            },
            enemyThree: {
                id: 0,
                name: "null",
                rank: "null",
                level: 0,
                healthPoints: 0,
                attackPoints: 0,
                defensePoints: 0,
                luckPoints: 0
            },
            profile: {
                nickname: "null",
                money: 0,
                energy: 0,
                rank: "null",
                level: 0,
                experience: 0,
                levelPoints: 0,
                healthPoints: 0,
                attackPoints: 0,
                defensePoints: 0,
                luckPoints: 0,
                intelligencePoints: 0
            },
            fightData: {
                attackerAttacks: [],
                opponentAttacks: [],
                winner: {
                    id: 0,
                    name: null,
                    healthPoints: 0,
                    attackPoints: 0,
                    defensePoints: 0,
                    luckPoints: 0,
                    weapon: null,
                    armour: null
                },
                looser: {
                    id: 0,
                    name: null,
                    healthPoints: 0,
                    attackPoints: 0,
                    defensePoints: 0,
                    luckPoints: 0,
                    weapon: null,
                    armour: null
                },
                winnerGold: 0,
                winnerExp: 0,
                looserGold: 0,
                looserExp: 0
            }
        };
    },
    mounted() {
        this.fetchProfile();
        this.fetchEnemy();
    },
    methods: {
        async fetchProfile(){
            try {
                const profileResponse = await axios.get(`http://localhost:5033/api/Student/GetStudentProfile${studentId}`);
                if (profileResponse.data.value.success) {
                    this.profile = profileResponse.data.value.data;
                    this.profile.rank = this.profile.rank.replace("_", " ");
                } else{
                    console.error("Failed to fetch profile: ", profileResponse.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching profile: ", error);
            }
        },
        getRandomId(){
            return Math.floor(Math.random() * 10) + 1;
        },
        async fetchEnemy(){
            try {
                // let enemies = [];
                // enemies.push(this.getRandomId());
                // enemies.push(this.getRandomId());
                // enemies.push(this.getRandomId());
                const enemyResponse1 = await axios.get(`http://localhost:5033/api/Enemy/GetEnemyBy1`); //${enemies[0]}
                const enemyResponse2 = await axios.get(`http://localhost:5033/api/Enemy/GetEnemyBy2`);
                const enemyResponse3= await axios.get(`http://localhost:5033/api/Enemy/GetEnemyBy3`);
                if (enemyResponse1.data.value.success) {
                    this.enemyOne = enemyResponse1.data.value.data;
                    this.enemyOne.rank = this.enemyOne.rank.replace("_", " ");
                } else{
                    console.error("Failed to fetch enemy ONE: ", enemyResponse1.data.value.message);
                }
                if (enemyResponse2.data.value.success) {
                    this.enemyTwo = enemyResponse2.data.value.data;
                    this.enemyTwo.rank = this.enemyTwo.rank.replace("_", " ");
                } else{
                    console.error("Failed to fetch enemy TWO: ", enemyResponse2.data.value.message);
                }
                if (enemyResponse3.data.value.success) {
                    this.enemyThree = enemyResponse3.data.value.data;
                    this.enemyThree.rank = this.enemyThree.rank.replace("_", " ");
                } else{
                    console.error("Failed to fetch enemy THREE: ", enemyResponse3.data.value.message);
                }
            }
            catch (error) {
                console.error("Error fetching enemy: ", error);
            }
        },
        async fightLocally() {
            const fightResponse = await axios.post(`http://localhost:5033/api/Fight/FightLocally${this.characters}`);
            if (fightResponse.data.value.success) {
                    this.fightData = fightResponse.data.value.data;
                    console.log(this.fightData);
                } else{
                    console.error("Failed to fight: ", fightResponse.data.value.message);
                }
        } 
    },
}
</script>