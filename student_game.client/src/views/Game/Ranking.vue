<template>
    <div class="min-h-screen p-4 text-slate-200">
        <h1 class="text-5xl font-bold text-center mb-8 text-blue-200">Ranking</h1>
        <div class="text-5xl font-bold text-center mb-4 flex justify-center gap-4">
            <span class="block bg-gradient-to-r from-blue-200 via-green-300 to-violet-400 bg-clip-text text-transparent">
                Jesteś na {{ studentPlace }} miejscu
            </span>
        </div>
    
        <div class="flex justify-center px-4 py-10">
            <div class="w-full max-w-screen-xl">
                <div class="rounded-xl shadow-md bg-gray-800">
                    <div class="p-4 border-b border-gray-700">
                        <h2 class="text-2xl font-semibold text-center">Statystyki</h2>
                    </div>
                    <div>
                        <table class="table-auto w-full text-left">
                            <thead>
                                <tr class="bg-gray-700 text-slate-200">
                                    <th class="py-3 px-4 hover:cursor-pointer" @click="sortTable('id')">
                                        #
                                        <span v-if="sortColumn === 'id'">{{ sortOrder === 'asc' ? '↑' : '↓' }}</span>
                                    </th>
                                    <th class="py-3 px-4 hover:cursor-pointer" @click="sortTable('nickname')">
                                        Imię
                                        <span v-if="sortColumn === 'nickname'">{{ sortOrder === 'asc' ? '↑' : '↓' }}</span>
                                    </th>
                                    <th class="py-3 px-4 hover:cursor-pointer" @click="sortTable('fights')">
                                        Walki
                                        <span v-if="sortColumn === 'fights'">{{ sortOrder === 'asc' ? '↑' : '↓' }}</span>
                                    </th>
                                    <th class="py-3 px-4 hover:cursor-pointer" @click="sortTable('victories')">
                                        Zwycięstwa
                                        <span v-if="sortColumn === 'victories'">{{ sortOrder === 'asc' ? '↑' : '↓' }}</span>
                                    </th>
                                    <th class="py-3 px-4 hover:cursor-pointer" @click="sortTable('defeats')">
                                        Przegrane
                                        <span v-if="sortColumn === 'defeats'">{{ sortOrder === 'asc' ? '↑' : '↓' }}</span>
                                    </th>
                                    <th class="py-3 px-4">
                                        Rangi
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="stats in sortedStatsArray" :key="stats.id" class="border-b border-gray-700 hover:bg-gray-600">
                                    <td class="py-3 px-4">{{ stats.id }}</td>
                                    <td class="py-3 px-4">{{ stats.nickname }}</td>
                                    <td class="py-3 px-4">{{ stats.fights }}</td>
                                    <td class="py-3 px-4">{{ stats.victories }}</td>
                                    <td class="py-3 px-4">{{ stats.defeats }}</td>
                                    <td class="py-3 px-4">{{ stats.rank }}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        </div>
</template>

<script>
    import axios from "axios";
    const studentId = 1;
    export default {
        data() {
            return {
                studentPlace: 0,
                statsArray: [],
                sortColumn: "",
                sortOrder: "asc",
            };
        },
        computed: {
            sortedStatsArray() {
            if (!this.sortColumn) return this.statsArray;

            return [...this.statsArray].sort((a, b) => {
                const valA = a[this.sortColumn];
                const valB = b[this.sortColumn];
                if (this.sortOrder === "asc") {
                return valA > valB ? 1 : valA < valB ? -1 : 0;
                } else {
                return valA < valB ? 1 : valA > valB ? -1 : 0;
                }
            });
            },
        },
        mounted() {
            this.fetchStats();
        },
        methods: {
            async fetchStats() {
                try {
                    const statsResponse = await axios.get("http://localhost:5033/api/Stat/GetAllStats");
                    if (statsResponse.data.value.success) {
                        this.statsArray = statsResponse.data.value.data;
                        this.calculateUserPlace();
                    } 
                    else {
                        console.error("Failed to fetch stats: ", statsResponse.data.value.message);
                    }
                } 
                catch (error) {
                    console.error("Error fetching stats: ", error);
                }
            },
            sortTable(column) {
                if (this.sortColumn === column) {
                    this.sortOrder = this.sortOrder === "asc" ? "desc" : "asc";
                } 
                else {
                    this.sortColumn = column;
                    this.sortOrder = "asc";
                }
            },
            calculateUserPlace() {
                // Sort the array by a ranking criterion (e.g., victories, fights, etc.)
                const sortedStats = [...this.statsArray].sort((a, b) => b.victories - a.victories || b.fights - a.fights);

                // Find the user's position in the sorted array
                const userIndex = sortedStats.findIndex((stats) => stats.id === studentId);

                // Convert 0-based index to 1-based ranking
                if (userIndex !== -1) {
                    this.studentPlace = userIndex + 1; // Update the place in the student stats
                } else {
                console.warn("User not found in stats array");
                }
            },
        },
    };
</script>