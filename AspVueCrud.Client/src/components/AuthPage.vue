<template>
  <div class="min-h-screen flex items-center justify-center bg-gradient-to-br from-gray-900 via-blue-900 to-blue-600">
    <LoginForm v-if="showLogin" @switchToRegister="showLogin = false" />
    <RegistrationForm v-else @switchToLogin="showLogin = true" />
  </div>
</template>

<script setup>
import { ref } from 'vue'
import LoginForm from './LoginForm.vue'
import RegistrationForm from './RegistrationForm.vue'

const showLogin = ref(true)
</script>