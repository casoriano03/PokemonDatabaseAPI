<script setup>
import axios from 'axios';
import { ref, watch } from 'vue';

const props = defineProps({
  open: Boolean,
  pokemon: Object,
});

const token = sessionStorage.getItem('authToken');
const emit = defineEmits(['update:open', 'submit']);

const formData = ref({
  pokedexEntryNumber: null,
  pokemonName: null,
  pokemonDescription: null,
  pokemonImgLink: null,
  pokemonAbilityId: null,
  pokemonType1Id: null,
  pokemonType2Id: null,
});

// Initialize formData when pokemon prop changes
watch(() => props.pokemon, (newPokemon) => {
  if (newPokemon) {
    formData.value = { ...newPokemon };
  }
}, { immediate: true });

const submitForm = async() => {
  if (validateForm()) {
    const response = await axios.put(`https://localhost:7252/api/Pokemon/EditPokemon?id=${formData.value.pokedexEntryNumber}`,
    formData.value,
      {
        headers: {
          "Authorization": `Bearer ${token}`, 
          "Content-Type": "application/json",
        },
      }
    );
    closeModal();
  } else {
    alert('Please fill out all required fields.');
  }
};

const closeModal = () => {
  emit('update:open', false);
};

const validateForm = () => {
  return (
    formData.value.pokedexEntryNumber !== null &&
    formData.value.pokemonName !== null &&
    formData.value.pokemonDescription !== null &&
    formData.value.pokemonImgLink !== null &&
    formData.value.pokemonAbilityId !== null &&
    formData.value.pokemonType1Id !== null
  );
};
</script>

<template>
 <div v-if="open" class="fixed inset-0 z-50 flex items-center justify-center">
  <div class="bg-gray-200 rounded-lg shadow-lg w-96 p-6">
    <h2 class="text-xl font-semibold mb-4">Edit Pokemon</h2>
    <form @submit="submitForm" class="grid grid-cols-1 md:grid-cols-2 gap-4">
      
      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokedex Entry Number:</label>
        <input v-model="formData.pokedexEntryNumber" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Name:</label>
        <input v-model="formData.pokemonName" type="text" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Description:</label>
        <input v-model="formData.pokemonDescription" type="text" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Image Link:</label>
        <input v-model="formData.pokemonImgLink" type="text" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Ability Id:</label>
        <input v-model="formData.pokemonAbilityId" type="number" class="w-full border p-2 rounded-md text-sm" required>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Type1 Id:</label>
        <select name="" id="" v-model="formData.pokemonType1Id" class="w-full border p-2 rounded-md text-sm" required>
          <option disabled value="">Select One</option>
          <option value="1">Normal</option>
          <option value="2">Fire</option>
          <option value="3">Water</option>
          <option value="4">Electric</option>
          <option value="5">Grass</option>
          <option value="6">Ice</option>
          <option value="7">Fighting</option>
          <option value="8">Poison</option>
          <option value="9">Ground</option>
          <option value="10">Flying</option>
          <option value="11">Psychic</option>
          <option value="12">Bug</option>
          <option value="13">Rock</option>
          <option value="14">Ghost</option>
          <option value="15">Dragon</option>
          <option value="16">Dark</option>
          <option value="17">Steel</option>
          <option value="18">Fairy</option>
        </select>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Type2 Id:</label>
        <select name="" id="" v-model="formData.pokemonType2Id" class="w-full border p-2 rounded-md text-sm" required>
          <option disabled value="">Select One</option>
          <option value="1">Normal</option>
          <option value="2">Fire</option>
          <option value="3">Water</option>
          <option value="4">Electric</option>
          <option value="5">Grass</option>
          <option value="6">Ice</option>
          <option value="7">Fighting</option>
          <option value="8">Poison</option>
          <option value="9">Ground</option>
          <option value="10">Flying</option>
          <option value="11">Psychic</option>
          <option value="12">Bug</option>
          <option value="13">Rock</option>
          <option value="14">Ghost</option>
          <option value="15">Dragon</option>
          <option value="16">Dark</option>
          <option value="17">Steel</option>
          <option value="18">Fairy</option>
          <option value="19">None</option>
        </select>
      </div>

      <div class="col-span-2 flex justify-end space-x-2">
        <button type="button" @click="closeModal" class="bg-gray-300 px-4 py-2 rounded-md">Cancel</button>
        <button type="submit" class="bg-blue-500 text-white px-4 py-2 rounded-md">Submit</button>
      </div>
    </form>
  </div>
 </div>
</template>