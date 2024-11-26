import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Landing-page/Home.vue'
import About from '../views/Landing-page/About.vue'
import Contact from '../views/Landing-page/Contact.vue'
import Login from '../views/Landing-page/Login.vue'
import Profile from '../views/Game/Profile.vue'
import Battle from '../views/Game/Battle.vue'
import ShopSell from '../views/Game/ShopSell.vue'
import ShopBuy from '../views/Game/ShopBuy.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/about',
        name: 'About',
        component: About
    },
    {
        path: '/contact',
        name: 'Contact',
        component: Contact
    },
    {
        path: '/login',
        name: 'Login',
        component: Login
    },
    {
        path: '/profile',
        name: 'Profile',
        component: Profile
    },
    {
        path: '/battle',
        name: 'Battle',
        component: Battle
    },
    {
        path: '/shop-buy',
        name: 'ShopBuy',
        component: ShopBuy
    },
    {
        path: '/shop-sell',
        name: 'ShopSell',
        component: ShopSell
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router