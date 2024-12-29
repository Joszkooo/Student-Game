<template>
    <div class="col-span-12 md:col-span-4 text-slate-200">
        <div class="card h-28 rounded-xl p-4 shop_background shadow-2xl">
            <div class="flex items-center justify-center gap-4">
                <v-progress-circular
                :model-value="value / maxValue * 100"
                :rotate="360"
                :size="80"
                :width="15"
                color="grey-lighten-2"
                class="flex-shrink-0"
                >
                    <span class="text-sm font-medium">{{ Math.round(value / maxValue * 100) }}%</span>
                </v-progress-circular>

                <p class="text-2xl md:text-3xl font-bold flex items-center gap-2">
                    <span :class="iconClass"></span>
                    <span class="whitespace-nowrap ml-5">{{ value }} / {{ maxValue }} {{ label }}</span>
                </p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "StatCard",
    props: {
        value: {
            type: Number,
            required: true,
        },
        maxValue: {
            type: Number,
            required: true,
        },
        label: {
            type: String,
            required: true,
        },
        iconClass: {
            type: String,
            required: true,
        },
    },
}
</script>

