<template>
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
        </v-list-item>
    </v-list>
</template>

<script>
export default {
    props: {
        hp: Number,
        attackPoints: Number,
        level: Number,
        defensePoints: Number,
        luckPoints: Number,
        rank: String
    }
}
</script>

