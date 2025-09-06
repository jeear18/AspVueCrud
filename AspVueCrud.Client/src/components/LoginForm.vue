<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="w-full max-w-md bg-white rounded-xl shadow-lg p-8">
      <h2 class="text-3xl font-bold text-center text-blue-700 mb-6">
        Sign in to your account
      </h2>
      <form @submit.prevent="onLogin">
        <div class="mb-4">
          <label class="block text-gray-700 mb-1" for="email">Email</label>
          <input
            id="email"
            v-model="email"
            type="email"
            required
            class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
            placeholder="you@email.com"
          />
        </div>
        <div class="mb-6">
          <label class="block text-gray-700 mb-1" for="password">Password</label>
          <input
            id="password"
            v-model="password"
            type="password"
            required
            class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
            placeholder="••••••••"
          />
        </div>
        <button
          type="submit"
          class="w-full bg-blue-700 hover:bg-blue-800 text-white font-semibold py-2 rounded-lg transition"
          :disabled="loading"
        >
          {{ loading ? "Signing in..." : "Sign In" }}
        </button>
      </form>

      <p class="mt-6 text-center text-gray-600 text-sm">
  Don't have an account?
  <router-link to="/register" class="text-blue-700 hover:underline ml-1">
    Sign up
  </router-link>
</p>

    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import api from '../axios'
import { useRouter } from 'vue-router'  // ✅ import

const email = ref('')
const password = ref('')
const loading = ref(false)

const router = useRouter()   // ✅ define router

async function onLogin() {
  loading.value = true
  try {
    const response = await api.post('/user/login', {
      Email: email.value,
      Password: password.value
    })

    alert(response.data.message) // ✅ "Login successful"
    console.log("User:", response.data.user)

    // 🔑 Save token & user for later use
    localStorage.setItem("user", JSON.stringify(response.data.user))
    if (response.data.token) {
      localStorage.setItem("token", response.data.token)
    }

    // 👉 Redirect to homepage
    router.push("/homepage")  // ✅ works now

  } catch (error) {
    if (error.response) {
      alert(error.response.data.message || "Invalid credentials")
    } else {
      alert("Server error")
    }
  } finally {
    loading.value = false
  }
}
</script>

