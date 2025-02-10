<script setup>
import { ref, computed, onMounted } from 'vue';
import EditPokemonModal from './EditPokemonModal.vue';
import EditOrAddStatsModal from './EditOrAddStatsModal.vue';
import axios from 'axios';
import { useRoute, useRouter } from 'vue-router';
import { jwtDecode } from 'jwt-decode';

const route = useRoute();
const router = useRouter();
const pokemonId = computed(()=> route.params.id); 
const isPokemonModalOpen = ref(false);
const isStatsModalOpen = ref(false);
const isAdmin = ref(false);
const token = sessionStorage.getItem("authToken")||null;

const props = defineProps({
    pokemon:{
        type:Object,
        default:() => ({}),
    },
    pokemonStats:{
        type:Object,
        default: () => ({}),
    },
});

const deletePokemon = async()=>{
  const response = await axios.delete(`https://localhost:7252/api/Pokemon/DeletePokemon?id=${pokemonId.value}`,
    {
        headers: {
          "Authorization": `Bearer ${token}`, 
          "Content-Type": "application/json",
        },
    }
  );
  router.push("/pokemon")
}

const getTokenPayLoad = (token)=>{
  if (token) {
    const decoded = jwtDecode(token);
    return decoded;
  }
    return null
}

onMounted(()=>{
  const decodedPayload = getTokenPayLoad(token)||null;
  if (decodedPayload && decodedPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] == "Admin") {
    isAdmin.value = true;
  }
})
</script>

<template>
    <div v-if="pokemon" class="p-6 bg-white shadow-lg rounded-lg text-center">
    <img :src="pokemon.pokemonImgLink" alt="Pokemon Image" class="w-40 h-40 mx-auto">
    <h2 class="text-2xl font-bold">{{ pokemon.pokemonName }}</h2>
    <p>{{ pokemon.pokemonDescription }}</p>
    
    <div class="mt-4">
      <span class="bg-[#98C8DE] text-white px-3 py-1 rounded-full mx-1">{{ pokemon.pokemonType1.typeName }}</span>
      <span v-if="pokemon.pokemonType2" class="bg-[#645AA4] text-white px-3 py-1 rounded-full mx-1">{{ pokemon.pokemonType2.typeName }}</span>
    </div>

    <p class="mt-3"><strong>Ability:</strong> {{ pokemon.pokemonAbility.abilityName }}</p>

    <div v-if="pokemonStats.pokemonId != null" class="mt-4">
      <p><strong>HP:</strong> {{ pokemonStats.hp }}</p>
      <p><strong>Attack:</strong> {{ pokemonStats.atk }}</p>
      <p><strong>Defense:</strong> {{ pokemonStats.def }}</p>
      <p><strong>Speed:</strong> {{ pokemonStats.spd }}</p>
      <p><strong>Special Attack:</strong> {{ pokemonStats.sAtk }}</p>
      <p><strong>Special Defense:</strong> {{ pokemonStats.sDef }}</p>
    </div>
    <div class="flex justify-center">
        <button v-if="isAdmin" @click="isPokemonModalOpen = true" class="rounded-md m-3 px-3 py-2 text-sm font-medium bg-[#313167] text-white hover:text-[#313167] hover:bg-white">Edit Pokemon</button>
        <button v-if="pokemonStats&&isAdmin" @click="isStatsModalOpen = true" class="rounded-md m-3 px-3 py-2 text-sm font-medium bg-[#313167] text-white hover:text-[#313167] hover:bg-white">Edit Stats</button>
        <button v-if="!pokemonStats&&isAdmin" @click="isStatsModalOpen = true" class="rounded-md m-3 px-3 py-2 text-sm font-medium bg-[#313167] text-white hover:text-[#313167] hover:bg-white">Add Stats</button>
        <button v-if="isAdmin" @click="deletePokemon" class="rounded-md m-3 px-3 py-2 text-sm font-medium bg-[#313167] text-white hover:text-[#313167] hover:bg-white">Delete Pokemon</button>
    </div>
  </div>
  <EditPokemonModal v-model:open="isPokemonModalOpen" :pokemon="pokemon" @close="isPokemonModalOpen = false" />
  <EditOrAddStatsModal v-model:openStats="isStatsModalOpen" :pokemonStats="pokemonStats" @close="isStatsModalOpen = false"/>
</template>