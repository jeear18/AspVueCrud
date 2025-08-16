<template>
  <div class="flex min-h-screen bg-gray-100">
    <!-- Sidebar -->
    <aside class="w-64 bg-white shadow-lg flex flex-col">
      <div class="h-16 flex items-center justify-center border-b">
        <span class="text-2xl font-bold text-blue-700">MyApp</span>
      </div>
      <nav class="flex-1 px-4 py-6">
        <ul class="space-y-2">
          <li>
            <a href="#" class="flex items-center px-3 py-2 rounded-lg text-gray-700 hover:bg-blue-100 transition">
              <!-- Home Icon -->
              <svg class="w-6 h-6 mr-3 text-blue-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" d="M3 12l9-9 9 9M4 10v10a1 1 0 001 1h3m10-11v10a1 1 0 01-1 1h-3m-6 0h6"></path>
              </svg>
              Home
            </a>
          </li>
          <li>
            <a href="#" class="flex items-center px-3 py-2 rounded-lg text-gray-700 hover:bg-blue-100 transition">
              <!-- User Icon -->
              <svg class="w-6 h-6 mr-3 text-blue-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" d="M5.121 17.804A9 9 0 1112 21a9 9 0 01-6.879-3.196z"></path>
                <path stroke-linecap="round" stroke-linejoin="round" d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"></path>
              </svg>
              Profile
            </a>
          </li>
          <li>
            <a href="#" class="flex items-center px-3 py-2 rounded-lg text-gray-700 hover:bg-blue-100 transition">
              <!-- Cog Icon -->
              <svg class="w-6 h-6 mr-3 text-blue-600" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" d="M11.049 2.927c.3-.921 1.603-.921 1.902 0a1.724 1.724 0 002.573 1.01c.797-.46 1.757.338 1.297 1.135a1.724 1.724 0 001.01 2.573c.921.3.921 1.603 0 1.902a1.724 1.724 0 00-1.01 2.573c.46.797-.338 1.757-1.135 1.297a1.724 1.724 0 00-2.573 1.01c-.3.921-1.603.921-1.902 0a1.724 1.724 0 00-2.573-1.01c-.797.46-1.757-.338-1.297-1.135a1.724 1.724 0 00-1.01-2.573c-.921-.3-.921-1.603 0-1.902a1.724 1.724 0 001.01-2.573c-.46-.797.338-1.757 1.135-1.297a1.724 1.724 0 002.573-1.01z"></path>
                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"></path>
              </svg>
              Settings
            </a>
          </li>
        </ul>
      </nav>
      <div class="p-4 border-t">
        <button class="w-full flex items-center justify-center px-3 py-2 rounded-lg text-white bg-blue-600 hover:bg-blue-700 transition">
          <!-- Logout Icon -->
          <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" stroke-width="2" viewBox="0 0 24 24">
            <path stroke-linecap="round" stroke-linejoin="round" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a2 2 0 01-2 2H7a2 2 0 01-2-2V7a2 2 0 012-2h4a2 2 0 012 2v1"></path>
          </svg>
          Logout
        </button>
      </div>
    </aside>
    <!-- Main Content -->
    <main class="flex-1 p-10">
      <h1 class="text-4xl font-bold text-gray-800 mb-4">Welcome Home!</h1>
      <p class="text-gray-600">This is your modern homepage with a sidebar menu and icons.</p>
    </main>
  </div>
</template>