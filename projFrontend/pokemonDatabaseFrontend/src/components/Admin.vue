<script setup>
import { ref } from 'vue';
import axios from 'axios';
import PokemonTypeDropdown from './PokemonTypeDropdown.vue';

const token = sessionStorage.getItem('authToken');
const formData = ref({
    pokedexEntryNumber:null,
    pokemonName:null,
    pokemonDescription:null,
    pokemonImgLink:null,
    pokemonAbilityId:null,
    pokemonType1Id:null,
    pokemonType2Id:null
});

const pokemonType2Dropdown = ref("Pokemon Type2 Id:")
const pokemonType1Dropdown = ref("Pokemon Type1 Id:")

const submitForm = async () =>{
  try {
    const response = await axios.post('https://localhost:7252/api/Pokemon/AddPokemon', formData.value,
    {
        headers: {
          "Authorization": `Bearer ${token}`, 
          "Content-Type": "application/json",
        },
      }
    );
    clearData();
    window.location.reload();
    alert(`Successfully added pokemon!`)
    
  } catch (error) {
    console.log(error)
  }   
}

const clearData = () =>{
  formData.value.pokedexEntryNumber = null,
  formData.value.pokemonName = null,
  formData.value.pokemonDescription = null,
  formData.value.pokemonImgLink = null,
  formData.value.pokemonAbilityId = null,
  formData.value.pokemonType1Id = null,
  formData.value.pokemonType2Id = null
};

</script>

<template>
<div class="w-1/3 m-auto ">
  <div class="">
    <h2 class="text-xl font-semibold mb-4 text-center py-3">Add Pokemon</h2>
    <form @submit.prevent="submitForm">
      
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

      <PokemonTypeDropdown :label="pokemonType1Dropdown" v-model="formData.pokemonType1Id"/>

      <PokemonTypeDropdown :label="pokemonType2Dropdown" v-model="formData.pokemonType2Id"/>

      <div class="col-span-2 flex justify-end space-x-2 mt-2">
        <button type="submit" class="bg-[#313167] text-white px-4 py-2 rounded-md">Add Pokemon</button>
      </div>
    </form>
  </div>
 </div>
</template>