<script setup>
import { ref, onMounted } from "vue";
import axios from "axios";

const products = ref([]);
const newProduct = ref({ name: "", price: "" });
const editingId = ref(null);
const editingProduct = ref({});

// Load products from API
const fetchProducts = async () => {
  try {
    const res = await axios.get("http://localhost:5053/api/product");
    products.value = res.data;
  } catch (err) {
    console.error("❌ Error fetching products:", err);
  }
};

// Add product
const addProduct = async () => {
  if (!newProduct.value.name || !newProduct.value.price) return;
  try {
    await axios.post("http://localhost:5053/api/product", newProduct.value);
    newProduct.value = { name: "", price: "" };
    fetchProducts();
  } catch (err) {
    console.error("❌ Error adding product:", err);
  }
};

// Start editing
const startEdit = (product) => {
  editingId.value = product.id;
  editingProduct.value = { ...product }; // clone
};

// Save edit
const saveEdit = async (id) => {
  try {
    await axios.put(`http://localhost:5053/api/product/${id}`, editingProduct.value);
    editingId.value = null;
    fetchProducts();
  } catch (err) {
    console.error("❌ Error updating product:", err);
  }
};

// Cancel edit
const cancelEdit = () => {
  editingId.value = null;
  editingProduct.value = {};
};

// Delete product
const deleteProduct = async (id) => {
  if (!confirm("Are you sure you want to delete this product?")) return;
  try {
    await axios.delete(`http://localhost:5053/api/product/${id}`);
    fetchProducts();
  } catch (err) {
    console.error("❌ Error deleting product:", err);
  }
};

onMounted(fetchProducts);
</script>

<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold mb-4">📦 Product List</h1>

    <!-- Add Product Form -->
    <div class="mb-6 p-4 border rounded-lg shadow">
      <h2 class="font-semibold mb-2">Add Product</h2>
      <div class="flex gap-2">
        <input
          v-model="newProduct.name"
          placeholder="Name"
          class="border px-2 py-1 rounded w-40"
        />
        <input
          v-model="newProduct.price"
          placeholder="price"
          class="border px-2 py-1 rounded w-40"
        />
        <button
          @click="addProduct"
          class="bg-blue-600 text-white px-3 py-1 rounded hover:bg-blue-700"
        >
          Add
        </button>
      </div>
    </div>

    <!-- Products Table -->
    <table class="w-full border-collapse border text-left">
      <thead>
        <tr class="bg-gray-100">
          <th class="border px-3 py-2">ID</th>
          <th class="border px-3 py-2">Name</th>
          <th class="border px-3 py-2">Price</th>
          <th class="border px-3 py-2">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="p in products" :key="p.id">
          <td class="border px-3 py-2">{{ p.id }}</td>

          <!-- Editing -->
          <td class="border px-3 py-2">
            <div v-if="editingId === p.id">
              <input v-model="editingProduct.name" class="border px-2 py-1 rounded" />
            </div>
            <div v-else>{{ p.name }}</div>
          </td>

          <td class="border px-3 py-2">
            <div v-if="editingId === p.id">
              <input v-model="editingProduct.price" class="border px-2 py-1 rounded" />
            </div>
            <div v-else>{{ p.price }}</div>
          </td>

          <!-- Actions -->
          <td class="border px-3 py-2">
            <div v-if="editingId === p.id">
              <button
                @click="saveEdit(p.id)"
                class="bg-green-600 text-white px-2 py-1 rounded mr-2 hover:bg-green-700"
              >
                Save
              </button>
              <button
                @click="cancelEdit"
                class="bg-gray-400 text-white px-2 py-1 rounded hover:bg-gray-500"
              >
                Cancel
              </button>
            </div>
            <div v-else>
              <button
                @click="startEdit(p)"
                class="bg-yellow-500 text-white px-2 py-1 rounded mr-2 hover:bg-yellow-600"
              >
                Edit
              </button>
              <button
                @click="deleteProduct(p.id)"
                class="bg-red-600 text-white px-2 py-1 rounded hover:bg-red-700"
              >
                Delete
              </button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>
