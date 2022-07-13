import { createApp } from 'vue'
import { createStore } from 'vuex'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import router from './router'
import store from './store'
import './assets/css/app.scss'



const app = createApp(App) //.use(dataStore)
app.use(store).use(router).use(ElementPlus).mount('#app')
