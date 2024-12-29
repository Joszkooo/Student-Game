<template>
    <div id="eq" class="col-span-12 md:col-span-8 shop_background rounded-xl shadow-2xl p-8">
        <span class="text-2xl font-bold flex text-center justify-center">Ekwipunek</span>
        <div class="card p-5">
            <v-table v-for="(category, index) in categories" :key="index" class="bg-[#454343] text-slate-200">
                <thead>
                    <tr class="bg-[#424242]">
                        <th v-for="header in category.headers" :key="header" class="text-left">
                            {{ header }}
                        </th>
                        <th class="text-left"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in equipment[category.key]" :key="item.id">
                        <td v-for="field in category.fields" :key="field">{{ item[field] }}</td>
                        <td class="text-right">
                            <button v-if="category.action" @click="category.action(item.id)">
                                {{ category.actionLabel }}
                            </button>
                        </td>
                    </tr>
                </tbody>
                <div class="mt-5"></div>
            </v-table>
            <hr v-if="index < categories.length - 1" class="h-px my-4 bg-gray-500 border-0 dark:bg-gray-700" />
        </div>
    </div>
</template>

<script>
export default {
    name: "EquipmentTable",
    props: {
        equipment: {
            type: Object,
            required: true,
        },
        equipArmour: {
            type: Function,
            required: false,
        },
        equipWeapon: {
            type: Function,
            required: false,
        },
    },
    computed: {
        categories() {
        return [
            {
                key: "armors",
                headers: ["Nazwa", "Defense", "Cena", "Rzadkość", "Ilość"],
                fields: ["name", "defense", "cost", "rarity", "quantity"],
                action: this.equipArmour,
                actionLabel: "Załóż",
            },
            {
                key: "foods",
                headers: ["Nazwa", "Typ buffa", "Czas trwania", "Cena", "Rzadkość", "Ilość"],
                fields: ["name", "boostType", "duration", "cost", "rarity", "quantity"],
                action: null,
                actionLabel: "",
            },
            {
                key: "weapons",
                headers: ["Nazwa", "Obrażenia", "Trafienie", "Cena", "Rzadkość", "Ilość"],
                fields: ["name", "damage", "hitChance", "cost", "rarity", "quantity"],
                action: this.equipWeapon,
                actionLabel: "Załóż",
            },
        ];
        },
    },
};
</script>
