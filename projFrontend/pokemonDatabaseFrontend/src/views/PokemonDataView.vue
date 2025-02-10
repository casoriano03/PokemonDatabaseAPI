<script setup>
import axios from 'axios';
import {onMounted, ref, computed } from 'vue';
import { useRoute } from 'vue-router';
import PokemonData from '@/components/PokemonData.vue';

const route = useRoute();
const pokemon = ref(null)
const pokemonStats = ref(null)
const pokemonId = computed(()=> route.params.id); 

onMounted(async() =>{
    try{ 
        const responsePokemon = await axios.get(`https://localhost:7252/api/Pokemon/GetPokemon?id=${pokemonId.value}`);
        const responseStats = await axios.get(`https://localhost:7252/api/PokemonStat/GetPokemonStat?pokemonId=${pokemonId.value}`);
        pokemon.value = responsePokemon.data;
        pokemonStats.value = responseStats.data;
    }catch(error){
        console.log(error)
    }
});
</script>

<template>
    <PokemonData :pokemon="pokemon" :pokemonStats="pokemonStats"/>
</template>