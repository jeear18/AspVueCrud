import { createRouter, createWebHistory } from 'vue-router'
import Login from './components/LoginForm.vue'
import Register from './components/RegistrationForm.vue'
import HomePage from './components/HomePage.vue'
import Products from './components/ProductList.vue'

const routes = [
  { path: '/', redirect: '/login' },
  { path: '/login', name: 'Login', component: Login },
  { path: '/register', name: 'Register', component: Register },
  { path: '/homepage', name: 'Homepage', component: HomePage },
  { path: '/products', name: 'Producst', component: Products },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
