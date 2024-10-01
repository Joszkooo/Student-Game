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
        <h1>Nadal wątpliwości?</h1>
        <h3>Sprawdz co sadza o nas inni gracze</h3>
        <div class="content-center">
            <Carousel
                class="relative w-full max-w-sm"
                :plugins="[Autoplay({
                    delay: 5000,
                })]"
                :opts="{
                align: 'start',
                loop: true,
                }">
                <CarouselContent class="-ml-1">
                <CarouselItem v-for="(_, index) in 5" :key="index" class="pl-1 md:basis-1/2 lg:basis-1/3">
                    <div class="p-1">
                    <Card>
                        <CardContent class="flex aspect-square items-center justify-center p-6">
                        <span class="text-2xl font-semibold">{{ index + 1 }}</span>
                        </CardContent>
                    </Card>
                    </div>
                </CarouselItem>
                </CarouselContent>
                <CarouselPrevious />
                <CarouselNext />
            </Carousel>
        </div>

        <Accordion type="single" collapsible>
            <AccordionItem value="item-1">
                <AccordionTrigger>Is it accessible?</AccordionTrigger>
                    <AccordionContent>
                        Yes. It adheres to the WAI-ARIA design pattern.
                    </AccordionContent>
            </AccordionItem>
        </Accordion>

        <TestimonialCard/>
    </div>
</template>

<script setup lang="ts">
    import { Button } from '@/components/ui/button'
    import Autoplay from 'embla-carousel-autoplay'
    import {
        Card,
        CardContent,
        CardDescription,
        CardFooter,
        CardHeader,
        CardTitle,
    } from '@/components/ui/card'

    import {
    Carousel,
    CarouselContent,
    CarouselItem,
    CarouselNext,
    CarouselPrevious,
    } from '@/components/ui/carousel'

    import { Accordion, AccordionContent, AccordionItem, AccordionTrigger } from '@/components/ui/accordion'

    import TestimonialCard from '@/components/TestimonialCard.vue'
</script>
