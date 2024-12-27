<template>
<div class="min-h-screen p-4">
        <h1 class="text-5xl font-bold text-center mb-8 text-slate-200">Ranking</h1>
        <div class="text-5xl font-bold text-center mb-4 flex justify-center gap-4">
            <h2 class=" text-yellow-400">Jesteś na </h2> 
            <span class="block bg-gradient-to-r from-yellow-400 to-amber-700 bg-clip-text text-transparent">{{ statsStudent.victories}}</span>
            <h2 class="text-5xl font-bold text-center gap-4 text-amber-700">miejscu</h2>
        </div>
        
        <div class="flex grow justify-center px-4 py-10">
            <div class="grid grid-cols-1 gap-6 ">
                <div class="w-full max-w-screen-md flex flex-col gap-8">
                    <div class="w-full flex flex-col gap-2">
                        pisze cos
                        <div class="shop_background rounded-lg shadow-md p-4 text-slate-200">
                            <h2 class="text-2xl font-semibold flex justify-center mb-4">Statystyki</h2>
                            <div v-for="stats in statsArray" :key="stats.id" class="border-b py-2 flex justify-between items-center">
                                <div>
                                    <p class="text-xl font-medium">{{ stats.id }}. {{ stats.fights }} walk | {{ stats.victories }} zwycięstw | {{ stats.defeats }} przegranych | imie</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
const studentId = 1;
export default {
    data() {
        return {
            statsArray: [],
            statsStudent: {
                id: 0,
                nickname: "none",
                fights: 0,
                victories: 0,
                defeats: 0
            }
        }
    },
    mounted() {
        this.fetchStats();
        this.fetchStudentStats();
    },
    methods: {
        async fetchStats(){
            try {
                const statsResponse = await axios.get("http://localhost:5033/api/Stat/GetAllStats");
                if (statsResponse.data.value.success){
                    this.statsArray = statsResponse.data.value.data;
                }else{
                    console.error("Failed to fetch stats: ", statsResponse.data.value.message);
                }
            } catch (error) {
                console.error("Error fetching stats: ", error);
            }
        },
        async fetchStudentStats(){
            try{
                const statsStudentResponse = await axios.get(`http://localhost:5033/api/Stat/${studentId}`);
                if (statsStudentResponse.data.value.success){
                        this.statsStudent = statsStudentResponse.data.value.data;
                }else{
                    console.error("Failed to fetch stats FOR STUDENT: ", statsStudentResponse.data.value.message);
                }
            } catch (error) {
                console.error("Error fetching stats FOR STUDENT: ", error);
            }
        }
    }
}
</script>