<script setup>
import axios from 'axios';
import { onMounted, ref } from 'vue';

const data = ref([]);
onMounted(async()=>{
    try{
        const response = await axios.get('https://localhost:7252/api/Pokemon/GetAllPokemons');
        data.value = response.data;
    } catch(error)
    {
        console.log(error);
    }
});

</script>

<template>
    <div class="p-3 m-top-3">
        <h1 class="text-3xl font-bold text-center">Pokémon List</h1>
    </div>
    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 p-5">
        <div v-for="pokemon in data" :key="pokemon.id" class="bg-gray-100 p-4 rounded-lg shadow-md">
            <img :src="pokemon.pokemonImgLink" :alt="pokemon.pokemonName" class="w-40 h-40 object-cover rounded-md m-auto">
            <h2 class="text-xl font-bold mt-2">{{ pokemon.pokemonName }}</h2>
            <p class="text-gray-700 text-sm">{{ pokemon.pokemonDescription }}</p>
            <p class="mt-2"><strong>Ability:</strong> {{ pokemon.pokemonAbility.abilityName }}</p>
            <p><strong>Type:</strong> {{ pokemon.pokemonType1.typeName }} / {{ pokemon.pokemonType2.typeName }}</p>
            <br>
            <RouterLink :to="`/pokemon/${pokemon.id}`" class="rounded-md px-3 py-2 text-sm font-medium bg-[#313167] text-white hover:text-[#313167] hover:bg-white">Read More</RouterLink>
        </div>
    </div>
</template>