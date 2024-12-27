<template>
    <header class="sticky top-5 shadow-lg">
        <nav>
            <div class="container flex justify-between items-center text-white py-5">
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Profile' }">Profil</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'ShopBuy' }">Sklep</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Battle' }">Bitwa</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Ranking' }">Ranking</router-link></a>
            </div>
        </nav>
    </header>

</template>
