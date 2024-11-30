import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/index.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import axios from 'axios'

const vuetify = createVuetify({
    components,
    directives,
})

const app = createApp(App) 

app.config.globalProperties.$axios = axios
app.use(router)
app.use(vuetify)
app.mount('#app')
