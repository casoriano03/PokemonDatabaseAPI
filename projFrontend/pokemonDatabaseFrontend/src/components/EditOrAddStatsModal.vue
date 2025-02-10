<script setup>
import axios from 'axios';
import { ref, watch, computed } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const pokemonId = computed(()=> route.params.id); 
const token = sessionStorage.getItem('authToken');
const emit = defineEmits(['update:openStats', 'submit']);

const props = defineProps({
  openStats:{
    type:Boolean,
    default:false
  }, 
  pokemonStats: {
    type:Object,
    deafult:() => ({})
  },
});

const formData = ref({
  hp:null,
  atk:null,
  def:null,
  spd:null,
  sAtk:null,
  sDef:null,
  pokemonId:pokemonId.value
});

watch(() => props.pokemonStats, (newStats) => {
  if (newStats) {
    formData.value = { ...newStats };
  }
}, { immediate: true });

const submit = async()=>{
  if (!props.pokemonStats.pokemonId) {
    const response = await axios.post(`https://localhost:7252/api/PokemonStat/AddPokemonStat`,formData.value,
  {
    headers: {
          "Authorization": `Bearer ${token}`, 
          "Content-Type": "application/json",
        },
  })
  } else {
    const response = await axios.put(`https://localhost:7252/api/PokemonStat/EditPokemonStat?id=${formData.value.pokemonId}`,formData.value,
  {
    headers: {
          "Authorization": `Bearer ${token}`, 
          "Content-Type": "application/json",
        },
  })
  }
  closeModal();
  setTimeout(()=>{
    window.location.reload();
  }, 500);
}


const closeModal = () => {
  emit('update:openStats', false);
};
</script>

<template>
<div v-if="openStats" class="fixed inset-0 z-50 flex items-center justify-center">
  <div class="bg-gray-200 rounded-lg shadow-lg w-96 p-6">
    <h2 class="text-xl font-semibold mb-4">Stats</h2>
    <form @submit.prevent="submit" class="grid grid-cols-1 md:grid-cols-2 gap-4">
      
      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Hp:</label>
        <input v-model="formData.hp" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Atk:</label>
        <input v-model="formData.atk" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Def:</label>
        <input v-model="formData.def" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Spd:</label>
        <input v-model="formData.spd" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">sAtk:</label>
        <input v-model="formData.sAtk" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">sDef:</label>
        <input v-model="formData.sDef" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Id:</label>
        <input v-model="formData.pokemonId" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="col-span-2 flex justify-end space-x-2">
        <button type="button" @click="closeModal" class="bg-gray-300 px-4 py-2 rounded-md">Cancel</button>
        <button type="submit" class="bg-blue-500 text-white px-4 py-2 rounded-md">Submit</button>
      </div>
    </form>
  </div>
 </div>
</template>