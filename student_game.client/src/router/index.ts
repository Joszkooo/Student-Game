import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Landing-page/Home.vue'
import About from '../views/Landing-page/About.vue'
import Contact from '../views/Landing-page/Contact.vue'
import Login from '../views/Landing-page/Login.vue'
import Profile from '../views/Game/Profile.vue'
import Battle from '../views/Game/Battle.vue'
import Gym from '../views/Game/Gym.vue'
import Shop from '../views/Game/Shop.vue'

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
        path: '/gym',
        name: 'Gym',
        component: Gym
    },
    {
        path: '/shop',
        name: 'Shop',
        component: Shop
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router