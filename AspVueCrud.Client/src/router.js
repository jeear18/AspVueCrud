import { createRouter, createWebHistory } from 'vue-router'
import Login from './components/LoginForm.vue'
import Register from './components/RegistrationForm.vue'
import HomePage from './components/HomePage.vue'
import Products from './components/ProductList.vue'
import MainLayout from './layouts/MainLayout.vue'
import AuthLayout from './layouts/AuthLayout.vue'

const routes = [
  {
    path: '/',
    redirect: '/homepage',
    component: MainLayout,
    children: [
      { path: 'homepage', component: HomePage },
      { path: 'products', component: Products },
    ]
  },
  {
    path: '/',
    component: AuthLayout,
    children: [
      { path: 'login', component: Login },
      { path: 'register', component: Register },
    ]
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
