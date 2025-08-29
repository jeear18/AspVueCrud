import { createRouter, createWebHistory } from 'vue-router'
import LoginForm from '../components/LoginForm.vue'
import ProductList from '../components/ProductList.vue'

const routes = [
  { path: '/', name: 'Login', component: LoginForm },  // 👈 default route
  { path: '/products', name: 'Products', component: ProductList }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
