<template>
    <div id="wrapper" class="min-h-screen p-5">
        <h1 class="text-white text-5xl text-center font-bold" id="chooseTitle">Wybierz swojego przeciwnika!</h1>
        <div class="flex justify-center mt-10" @click="this.fetchEnemy();">
            <button id="refresh" type='button'
            class='py-2.5 pl-4 group pr-3.5 text-sm bg-white text-slate-200 shadow-neon rounded-full cursor-pointer font-semibold text-center shadow-xs transition-all duration-500 flex gap-2 items-center hover:bg-indigo-700'>
            Odśwież
            <svg class="transition-all duration-700 group-hover:animate-spin"
            xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"
            fill="none">
                <path
                    d="M18.6793 11.776C18.6793 12.2186 19.0381 12.5774 19.4807 12.5774C19.9233 12.5774 20.2821 12.2186 20.2821 11.776H18.6793ZM3.75105 8.55933C3.58499 8.96958 3.78294 9.43677 4.19319 9.60283C4.60344 9.7689 5.07063 9.57095 5.23669 9.1607L3.75105 8.55933ZM5.3214 12.224C5.3214 11.7814 4.96261 11.4226 4.52003 11.4226C4.07744 11.4226 3.71866 11.7814 3.71866 12.224H5.3214ZM20.2497 15.4407C20.4157 15.0304 20.2178 14.5632 19.8075 14.3972C19.3973 14.2311 18.9301 14.4291 18.764 14.8393L20.2497 15.4407ZM19.5043 11.7988L19.0401 12.452C19.4009 12.7084 19.9012 12.6237 20.1575 12.2629L19.5043 11.7988ZM17.0297 9.0573C16.669 8.80094 16.1687 8.88558 15.9123 9.24636C15.656 9.60713 15.7406 10.1074 16.1014 10.3638L17.0297 9.0573ZM22.2457 9.32421C22.5021 8.96344 22.4175 8.46315 22.0567 8.20679C21.6959 7.95042 21.1956 8.03507 20.9393 8.39584L22.2457 9.32421ZM4.49642 12.2012L4.9606 11.548C4.59983 11.2916 4.09954 11.3763 3.84318 11.7371L4.49642 12.2012ZM6.97097 14.9427C7.33174 15.1991 7.83203 15.1144 8.08839 14.7536C8.34475 14.3929 8.26011 13.8926 7.89933 13.6362L6.97097 14.9427ZM1.75496 14.6758C1.4986 15.0366 1.58324 15.5369 1.94402 15.7932C2.30479 16.0496 2.80508 15.9649 3.06145 15.6042L1.75496 14.6758ZM11.7047 4.80137C15.5567 4.80137 18.6793 7.92403 18.6793 11.776H20.2821C20.2821 7.03886 16.4418 3.19863 11.7047 3.19863V4.80137ZM5.23669 9.1607C6.27196 6.60316 8.77885 4.80137 11.7047 4.80137V3.19863C8.10371 3.19863 5.02289 5.41737 3.75105 8.55933L5.23669 9.1607ZM12.2961 19.1986C8.44406 19.1986 5.3214 16.076 5.3214 12.224H3.71866C3.71866 16.9611 7.55889 20.8014 12.2961 20.8014V19.1986ZM18.764 14.8393C17.7288 17.3968 15.2219 19.1986 12.2961 19.1986V20.8014C15.897 20.8014 18.9778 18.5826 20.2497 15.4407L18.764 14.8393ZM19.9685 11.1455L17.0297 9.0573L16.1014 10.3638L19.0401 12.452L19.9685 11.1455ZM20.9393 8.39584L18.851 11.3346L20.1575 12.2629L22.2457 9.32421L20.9393 8.39584ZM4.03224 12.8545L6.97097 14.9427L7.89933 13.6362L4.9606 11.548L4.03224 12.8545ZM3.06145 15.6042L5.14966 12.6654L3.84318 11.7371L1.75496 14.6758L3.06145 15.6042Z"
                    fill="currentcolor" />
                </svg>
        </button>
        </div>
        
        
        <div id="choose" class="p-10 grid grid-cols-1 md:grid-cols-3 gap-6 ">
            <div id="first" class="bg-white p-5 hover:cursor-pointer" @click="chooseEnemy(enemyOne.id)">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyOne.name }}</h1>
                <img :src="getEnemyPicture(enemyOne.id)" />
                <PlayerCard 
                    :attackPoints="enemyOne.attackPoints"
                    :level="enemyOne.level"
                    :defensePoints="enemyOne.defensePoints"
                    :luckPoints="enemyOne.luckPoints"
                    :rank = "enemyOne.rank"
                    :hp = "enemyOne.healthPoints"
                ></PlayerCard>
            </div>
            <div id="second" class="bg-white p-5 hover:cursor-pointer " @click="chooseEnemy(enemyTwo.id)">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyTwo.name }}</h1>
                <img :src="getEnemyPicture(enemyTwo.id)" />
                <PlayerCard 
                    :attackPoints="enemyTwo.attackPoints"
                    :level="enemyTwo.level"
                    :defensePoints="enemyTwo.defensePoints"
                    :luckPoints="enemyTwo.luckPoints"
                    :rank = "enemyTwo.rank"
                    :hp = "enemyTwo.healthPoints"
                ></PlayerCard>
            </div>
            <div id="third" class="bg-white p-5 hover:cursor-pointer " @click="chooseEnemy(enemyThree.id)">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyThree.name }}</h1>
                <img :src="getEnemyPicture(enemyThree.id)" />
                <PlayerCard 
                    :attackPoints="enemyThree.attackPoints"
                    :level="enemyThree.level"
                    :defensePoints="enemyThree.defensePoints"
                    :luckPoints="enemyThree.luckPoints"
                    :rank = "enemyThree.rank"
                    :hp = "enemyThree.healthPoints"
                ></PlayerCard>
            </div>
        </div>
        <div id="fight" class="p-10  grid-cols-1 md:grid-cols-3 gap-6 hidden">
            <div id="student" class="bg-white p-5">
                <h1 class="text-black text-2xl text-center font-bold">{{ profile.nickname }}</h1>
                <img src="/Player.jpg" />
                <PlayerCard
                    :attackPoints="profile.attackPoints"
                    :level="profile.level"
                    :defensePoints="profile.defensePoints"
                    :luckPoints="profile.luckPoints",
                    :rank="profile.rank"
                    :hp = "profile.healthPoints"
                ></PlayerCard>
            </div>
            <button @click="fightLocally(this.characters); fightEnd = true" class="bg-white">
                FIGHT!
            </button>
            <div id="enemy" class="bg-white p-5">
                <h1 class="text-black text-2xl text-center font-bold">{{ enemyFight.name }}</h1>
                <img :src="getEnemyPicture(enemyFight.id)" />
                <PlayerCard
                    :attackPoints="enemyFight.attackPoints"
                    :level="enemyFight.level"
                    :defensePoints="enemyFight.defensePoints"
                    :luckPoints="enemyFight.luckPoints",
                    :rank="enemyFight.rank"
                    :hp = "enemyFight.healthPoints"
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
            class="text-center"
        >
        <v-card-title> {{ fightResultMessage }}</v-card-title>
        <v-card-text class="text-center">
            <p>Imie wygranego: {{ fightData.winner.name }}</p>
            <p>Złoto wygranego: {{ fightData.winnerGold }}</p>
            <p>Exp wygranego: {{ fightData.winnerExp }}</p>
            <p>Imie przegranego: {{ fightData.looser.name }}</p>
        </v-card-text>
        <template v-slot:actions>
            <v-btn
                class="ms-auto hover:underline"
                text="Nowa walka!"
                @click="this.fetchEnemy(); fightEnd = false; chooseTitle.style.display = 'grid'; chooseTitle.style.display = 'grid'; refresh.style.display = 'grid';"
            ></v-btn>
            <router-link :to="{ name: 'Profile' }">Powrót do proflu</router-link>
        </template>
        </v-card>
    </v-dialog>
</template>

<script>
import PlayerCard from "@/components/PlayerCard.vue";
import axios from "axios";
const studentId = 1;

export default{
    components: {PlayerCard},
    data() {
        return{
            fightResultMessage: "null",
            enemyId: 0,
            fightEnd: false,
            characters:{
                "attackerId": studentId,
                "opponentId": 0
            },
            enemyPicture: [
                "/Goblin.jpg",
                "/Orc.jpg",
                "/Troll.jpg",
                "/Dragon.jpg",
                "/Skeleton.jpg",
                "/Zombie.jpg",
                "/Vampire.jpg",
                "/Werewolf.jpg",
                "/Demon.jpg",
                "/Witch.jpg"
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
            enemyFight: {
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
        chooseEnemy(enemyId){
            choose.style.display = 'none';
            fight.style.display = "grid";
            if (enemyId == this.enemyOne.id){
                this.enemyFight = this.enemyOne;
                this.characters.opponentId = enemyId;
            }
            else if (enemyId == this.enemyTwo.id){
                this.enemyFight = this.enemyTwo;
                this.characters.opponentId = enemyId;
            }
            else if (enemyId == this.enemyThree.id){
                this.enemyFight = this.enemyThree;
                this.characters.opponentId = enemyId;
            }
            chooseTitle.style.display = 'none';
            chooseTitle.style.display = 'none';
            refresh.style.display = 'none';
        },
        getEnemyPicture(enemyId) {
            const index = enemyId - 1;
            return this.enemyPicture[index];
        },
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
                let enemies = [];
                enemies.push(this.getRandomId());
                enemies.push(this.getRandomId());
                enemies.push(this.getRandomId());
                const enemyResponse1 = await axios.get(`http://localhost:5033/api/Enemy/GetEnemyBy${enemies[0]}`);
                const enemyResponse2 = await axios.get(`http://localhost:5033/api/Enemy/GetEnemyBy${enemies[1]}`);
                const enemyResponse3= await axios.get(`http://localhost:5033/api/Enemy/GetEnemyBy${enemies[2]}`);
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
            const fightResponse = await axios.post(`http://localhost:5033/api/Fight/FightLocally`, this.characters);
            if (fightResponse.data.value.success) {
                    this.fightData = fightResponse.data.value.data;
                    if (this.fightData.winner.name == "Student"){
                        this.fightResultMessage = "Wygrana!";
                        this.incrementBattle(true);
                    }else{
                        this.fightResultMessage = "Przegrana!"
                        this.incrementBattle(false);
                    }
                    console.log(this.fightData);
                } else{
                    console.error("Failed to fight: ", fightResponse.data.value.message);
                }
        },
        async incrementBattle(fightResult) {
            if (fightResult == true){
                await axios.post(`http://localhost:5033/api/Stat/IncrementVictories?id=${studentId}`);
            }else {
                await axios.post(`http://localhost:5033/api/Stat/IncrementDefeats?id=${studentId}`);
            }
            if(incrementResult.data.value.success) {
                console.log(incrementResult.data.value.data);
            }else {
                console.error("Error while incrementing battle info");
            }
        },
    },
}
</script>