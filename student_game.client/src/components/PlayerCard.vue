<template>
<<<<<<< Updated upstream
    <v-card
        class="mx-auto"
        max-width="400"
    >
        <v-card-item :title="name">
        <template v-slot:subtitle>
            <v-icon
            class="me-1 pb-1"
            color="red"
            icon="mdi mdi-chevron-triple-up"
            size="18"
            ></v-icon>
            {{ rank }}
        </template>
        </v-card-item>
=======
    <v-row class="d-flex py-3 justify-center text-center">
        <v-col cols="4" xs="4" sm="4" md="4" lg="4" xl="4">
            <v-list-item
                density="compact"
                prepend-icon="mdi mdi-sword"
            >
                <v-list-item-subtitle class="text-neutral-950">{{ attackPoints }} ATK</v-list-item-subtitle>
            </v-list-item>
        </v-col>
    
        <v-col cols="4" xs="4" sm="4" md="4" lg="4" xl="4">
            <v-list-item
                density="compact"
                prepend-icon="mdi-heart-outline"
            >
                <v-list-item-subtitle class="text-neutral-950"> {{ hp }} HP</v-list-item-subtitle>
            </v-list-item>
        </v-col>
        <!-- mdi mdi-one-up {{ rank }} -->
    
        <v-col cols="4" xs="4" sm="4" md="4" lg="4" xl="4">
            <v-list-item
                density="compact"
                prepend-icon="mdi mdi-shield-outline"
            >
                <v-list-item-subtitle class="text-neutral-950">{{ defensePoints }} DEF</v-list-item-subtitle>
            </v-list-item>
        </v-col>
    </v-row>
    <v-list class="bg-transparent">
        <v-list-item 
            density="compact" 
            prepend-icon="mdi mdi-clover"
            >
            <v-row class="w-full items-center">
                <v-col>
                    <v-list-item-title>Luck Points</v-list-item-title>
                </v-col>
                <v-col class="text-green text-right">
                    <v-list-item-subtitle>+{{ luckPoints }} LUCK</v-list-item-subtitle>
                </v-col>
            </v-row>
        </v-list-item>
>>>>>>> Stashed changes

        <v-card-text class="py-0">
            <v-row align="center" no-gutters>
                <v-col
                class="text-h4"
                cols="6"
                >
                {{ hp }} HP
                </v-col>

                <v-col class="text-right" cols="6">
                <v-icon
                    color="red"
                    icon="mdi mdi-account"
                    size="88"
                ></v-icon>
                </v-col>
            </v-row>
<<<<<<< Updated upstream
        </v-card-text>

        <v-row class="d-flex py-3 justify-center text-center">
            <v-col cols="4" xs="4" sm="4" md="4" lg="4" xl="4">
                <v-list-item
                    density="compact"
                    prepend-icon="mdi mdi-sword"
                >
                    <v-list-item-subtitle class="text-neutral-950">{{ atk }} ATK</v-list-item-subtitle>
                </v-list-item>
            </v-col>
            
            <v-col cols="4" xs="4" sm="4" md="4" lg="4" xl="4">
                <v-list-item
                    density="compact"
                    prepend-icon="mdi mdi-one-up"
                >
                    <v-list-item-subtitle class="text-neutral-950">{{ lvl }} LVL</v-list-item-subtitle>
                </v-list-item>
            </v-col>
            
            <v-col cols="4" xs="4" sm="4" md="4" lg="4" xl="4">
                <v-list-item
                    density="compact"
                    prepend-icon="mdi mdi-shield-outline"
                >
                    <v-list-item-subtitle class="text-neutral-950">{{ def }} DEF</v-list-item-subtitle>
                </v-list-item>
            </v-col>
        </v-row>
        
        <v-divider inset></v-divider>
        
        <v-expand-transition>
            <div v-if="expand">
                
                <v-list class="bg-transparent">
                    <v-list-item 
                        density="compact" 
                        prepend-icon="mdi mdi-clover"
                        >
                        <v-row class="w-full items-center">
                            <v-col>
                                <v-list-item-title>Luck Points</v-list-item-title>
                            </v-col>
                            <v-col class="text-green text-right">
                                <v-list-item-subtitle>+{{ luck }} LUCK</v-list-item-subtitle>
                            </v-col>
                        </v-row>
                    </v-list-item>

                    <v-list-item 
                        density="compact" 
                        prepend-icon="mdi mdi-brain"
                        >
                        <v-row class="w-full items-center">
                            <v-col>
                                <v-list-item-title>Intelligence Points</v-list-item-title>
                            </v-col>
                            <v-col class="text-green text-right">
                                <v-list-item-subtitle>+{{ int }} INT</v-list-item-subtitle>
                            </v-col>
                        </v-row>
                    </v-list-item>

                    <v-list-item 
                        density="compact" 
                        prepend-icon="mdi mdi-pistol"
                        >
                        <v-row class="w-full items-center">
                            <v-col>
                                <v-list-item-title>Weapon</v-list-item-title>
                            </v-col>
                            <v-col class="text-violet-900 text-right">
                                <v-list-item-subtitle>{{ weapon }}</v-list-item-subtitle>
                            </v-col>
                        </v-row>
                    </v-list-item>

                    <v-list-item 
                        density="compact" 
                        prepend-icon="mdi mdi-tshirt-crew-outline"
                        >
                        <v-row class="w-full items-center">
                            <v-col>
                                <v-list-item-title>Armour</v-list-item-title>
                            </v-col>
                            <v-col class="text-violet-900 text-right">
                                <v-list-item-subtitle>{{ armour }}</v-list-item-subtitle>
                            </v-col>
                        </v-row>
                    </v-list-item>

                </v-list>
            
            </div>
        </v-expand-transition>

        <v-divider></v-divider>

        <v-card-actions>
        <v-btn
            :text="!expand ? 'Full Stats' : 'Hide Stats'"
            @click="expand = !expand"
        ></v-btn>
        </v-card-actions>
    </v-card>
=======
        </v-list-item>
    </v-list>
>>>>>>> Stashed changes
</template>

<script>
export default {
    props: {
<<<<<<< Updated upstream
        name: { type: String, default: "Player" },
        rank: { type: String, default: "Silver I" },
        hp: { type: Number, default: 100 },
        atk: { type: Number, default: 1 },
        lvl: { type: Number, default: 1},
        def: { type: Number, default: 1 },
        luck: { type: Number, default: 1 },
        int: { type: Number, default: 1 },
        weapon: {type: String, default: "Glock-18"},
        armour: {type: String, default: "Leather Armour"},
    },
    data: () => ({
    expand: false,
    }),
=======
        hp: Number,
        attackPoints: Number,
        level: Number,
        defensePoints: Number,
        luckPoints: Number,
        rank: String
    }
>>>>>>> Stashed changes
}
</script>

