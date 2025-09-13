<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const stats = ref({
  users_count: 0,
  products_count: 0,
});

onMounted(async () => {
  try {
    const response = await axios.get("http://localhost:5053/api/dashboard/stats"); 
    stats.value = response.data;
  } catch (error) {
    console.error("Error fetching stats:", error);
  }
});
</script>

<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-6">Dashboard</h1>

    <div class="grid grid-cols-1 sm:grid-cols-2 gap-6">
      <!-- Users -->
      <div class="bg-white shadow rounded-lg p-6 flex items-center">
        <svg class="w-10 h-10 text-blue-600 mr-4" fill="none" stroke="currentColor" stroke-width="2"
          viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M17 20h5v-2a4 4 0 00-4-4H6a4 4 0 00-4 4v2h5"></path>
          <circle cx="12" cy="7" r="4"></circle>
        </svg>
        <div>
          <p class="text-gray-500">Users</p>
          <p class="text-2xl font-bold">{{ stats.users_count }}</p>
        </div>
      </div>

      <!-- Products -->
      <div class="bg-white shadow rounded-lg p-6 flex items-center">
        <svg class="w-10 h-10 text-green-600 mr-4" fill="none" stroke="currentColor" stroke-width="2"
          viewBox="0 0 24 24">
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M20 13V7a2 2 0 00-2-2H6a2 2 0 00-2 2v6"></path>
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M20 13a2 2 0 01-2 2H6a2 2 0 01-2-2"></path>
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M4 13v6a2 2 0 002 2h12a2 2 0 002-2v-6"></path>
        </svg>
        <div>
          <p class="text-gray-500">Products</p>
          <p class="text-2xl font-bold">{{ stats.products_count }}</p>
        </div>
      </div>
    </div>
  </div>
</template>
