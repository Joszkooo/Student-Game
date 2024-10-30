<template>
    <v-row dense>
        <v-col
            v-for="item in items"
            :key="item.id"
            class="p-4"
            cols="12"
            md="4"
            lg="3"
        >
            <v-card>
                <v-card-title>{{ item.name }}</v-card-title>
                <v-card-subtitle>{{ item.price }} Gold</v-card-subtitle>
                <v-card-actions>
                    <v-btn color="primary" @click="$emit('purchase', item)">
                    Buy
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-col>
    </v-row>
</template>

<script setup>
    import { defineProps } from 'vue';
    
    const props = defineProps({
        items: {
        type: Array,
        required: true
        }
    });
</script>