<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="bg-white/90 rounded-xl shadow-lg p-8 w-full max-w-md">
      <h2 class="text-3xl font-bold text-center text-blue-700 mb-6">Create an account</h2>
      <form @submit.prevent="onRegister">
        <div class="mb-4">
          <label class="block text-gray-700 mb-1" for="name">Name</label>
          <input
            id="name"
            v-model="name"
            type="text"
            required
            class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-400"
            placeholder="Your Name"
          />
        </div>
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
        >
          Register
        </button>
      </form>
      <p class="mt-6 text-center text-gray-600 text-sm">
        Already have an account?
        <router-link to="/login" class="text-blue-700 hover:underline">Sign in</router-link>
      </p>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import api from '../axios'
import { useRouter } from "vue-router"

const router = useRouter()   // ✅ make sure router is defined

const name = ref('')
const email = ref('')
const password = ref('')

async function onRegister() {
  try {
    const response = await api.post("/user/register", {
      username: name.value,
      email: email.value,
      password: password.value
    })

    // ✅ check if success
    if (response.status === 200) {
      alert(response.data.message)
      console.log("Registered User:", response.data)

      // ✅ redirect to login
      router.push("/login")
    }
  } catch (error) {
    if (error.response) {
      alert(error.response.data.message)
      console.error("API Error:", error.response)
    } else {
      alert("Server error")
      console.error("Other Error:", error)
    }
  }
}

</script>
