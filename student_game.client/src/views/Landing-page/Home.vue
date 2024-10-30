<template>
    <div class="text-center p-20 m-20" >
        <h1 class="text-7xl text-slate-100 text-center pt-3 font-bold header-landing">
            Stwórz swojego
            <span class="block text-transparent bg-clip-text bg-gradient-to-r from-blue-500 via-pink-500 to-blue-500">Studenta</span>
        </h1>
        <p class="pt-3 font-medium text-xl text-gray-200">&& pokonaj wszystkich na swojej drodze</p>
        <Button class="rounded-full mt-2 shadow-neon bg-black-500"> 
            <router-link :to="{ name: 'Login' }">Zacznij teraz!</router-link>
        </Button>
        
        <div class="text-center flex content-center">
            <Card class="m-20 px-30 basis-1/3">
                <CardHeader>
                    <CardTitle>Walcz z przeciwnikami</CardTitle>
                </CardHeader>
                <CardContent>
                    Doświadcz setki przeciwników którzy czekają aż się z nimi zmierzysz
                </CardContent>
            </Card>

            <Card class="m-20 px-30 basis-1/3">
                <CardHeader>
                    <CardTitle>Zdobywaj epickie przedmioty</CardTitle>
                </CardHeader>
                <CardContent>
                    Wywalcz sobie droge do chwały
                </CardContent>
            </Card>

            <Card class="m-20 px-30 basis-1/3">
                <CardHeader>
                    <CardTitle>Rozmawiaj z innymi</CardTitle>
                </CardHeader>
                <CardContent>
                    Poznawaj i twórz przyjaźnie podczas swojej przygody
                </CardContent>
            </Card>

            <Card class="m-20 px-30">
                <CardHeader>
                    <CardTitle>Zdobywaj epickie przedmioty</CardTitle>
                </CardHeader>
                <CardContent>
                    Setki przeciwników czeka aż się z nimi zmierzysz
                </CardContent>
            </Card>
        </div>
    </div>
</template>

<script setup lang="ts">
    import { Button } from '@/components/ui/button'
    import {
        Card,
        CardContent,
        CardDescription,
        CardFooter,
        CardHeader,
        CardTitle,
    } from '@/components/ui/card'
</script>
