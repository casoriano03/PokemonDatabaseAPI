<script setup>
import { ref } from 'vue';
import axios from 'axios';

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
    alert(`Successfully added ${formData.value.pokemonName}`)
    formData.value.pokedexEntryNumber = null,
    formData.value.pokemonName = null,
    formData.value.pokemonDescription = null,
    formData.value.pokemonImgLink = null,
    formData.value.pokemonAbilityId = null,
    formData.value.pokemonType1Id = null,
    formData.value.pokemonType2Id = null
  } catch (error) {
    
  }
    
}

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

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Type1 Id:</label>
        <select name="" id="" v-model="formData.pokemonType1Id" class="w-full border p-2 rounded-md text-sm" required>
          <option disabled value="">Select One</option>
          <option value=1>Normal</option>
          <option value=2>Fire</option>
          <option value=3>Water</option>
          <option value=4>Electric</option>
          <option value=5>Grass</option>
          <option value=6>Ice</option>
          <option value=7>Fighting</option>
          <option value=8>Poison</option>
          <option value=9>Ground</option>
          <option value=10>Flying</option>
          <option value=11>Psychic</option>
          <option value=12>Bug</option>
          <option value=13>Rock</option>
          <option value=14>Ghost</option>
          <option value=15>Dragon</option>
          <option value=16>Dark</option>
          <option value=17>Steel</option>
          <option value=18>Fairy</option>
        </select>
      </div>

      <div class="flex flex-col">
        <label class="block mb-1 text-sm">Pokemon Type2 Id:</label>
        <select name="" id="" v-model="formData.pokemonType2Id" class="w-full border p-2 rounded-md text-sm">
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

      <div class="col-span-2 flex justify-end space-x-2 mt-2">
        <button type="submit" class="bg-[#313167] text-white px-4 py-2 rounded-md">Add Pokemon</button>
      </div>
    </form>
  </div>
 </div>
</template>