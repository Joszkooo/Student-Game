<template>
    <header class="sticky top-5 shadow-lg">
        <nav>
            <div class="container flex justify-between items-center text-white py-5 divide-x divide-solid">
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Profile' }">Profil</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'ShopBuy' }">Sklep</router-link></a>
                <a class="hover:underline cursor-pointer duration-100 hover:text-gray-300"><router-link :to="{ name: 'Battle' }">Bitwa</router-link></a>
            </div>
        </nav>
    </header>

</template>

<script setup>
    // <header class="sticky top-5 shadow-lg">
    //         <nav class="container flex justify-between items-center w-[92%]  mx-auto text-white py-5 ">
    //             <div class=" duration-500 md:static absolute  md:min-h-fit min-h-[60vh] left-0 top-[-100%] md:w-auto  w-full flex items-center px-5">
    //                 <ul class="flex md:flex-row flex-col md:items-center md:gap-[4vw] gap-8">
    //                     <li>
    //                         <a class="hover:text-grey-300"><router-link :to="{ name: 'Profile' }">Postać</router-link></a>
    //                     </li>
    //                     <li>
    //                         <a class="hover:text-grey-300"><router-link :to="{ name: 'Shop' }">Sklep</router-link></a>
    //                     </li>
    //                     <li>
    //                         <a class="hover:text-grey-300"><router-link :to="{ name: 'Battle' }">Bitwa</router-link></a>
    //                     </li>
    //                     <li>
    //                         <a class="hover:text-grey-300"><router-link :to="{ name: 'Gym' }">Siłownia</router-link></a>
    //                     </li>
    //                 </ul>
    //             </div>
    //         </nav>
    //     </header>
</script>

