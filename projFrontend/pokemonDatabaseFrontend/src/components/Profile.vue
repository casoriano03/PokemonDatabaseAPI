<script setup>
import { jwtDecode } from 'jwt-decode';
import { ref, onMounted } from 'vue';

const token = sessionStorage.getItem("authToken");

const username = ref("");
const email = ref("");
const role = ref("");

const getTokenPayLoad = (token)=>{
    const decoded = jwtDecode(token);
    return decoded;
}

onMounted (()=>{
    const decodedPayload = getTokenPayLoad(token);
    username.value = decodedPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
    email.value = decodedPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
    role.value = decodedPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
});
</script>

<template>
    <div class="">
        <div class="bg-gray-100 rounded-lg shadow-lg w-150 h-100 flex items-center p-6">
  <div class="w-1/3 flex justify-center">
    <img
      src="https://pokemonletsgo.pokemon.com/assets/img/common/char-pikachu.png"
      alt="Profile Picture"
      class="w-32 h-32 rounded-full border-4 border-[#98C8DE]"
    />
  </div>
  <div class="w-2/3">
    <h2 class="text-xl font-semibold text-gray-900">Username: {{ username }}</h2>
    <p class="text-gray-900">Email: {{ email }}</p>
    <span class="inline-block bg-[#98C8DE] text-gray-900 text-sm px-3 py-1 rounded-full mt-2">
      Role: {{ role }}
    </span>
  </div>
</div>
    </div>
</template>