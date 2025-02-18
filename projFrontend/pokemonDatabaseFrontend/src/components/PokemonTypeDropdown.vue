<script setup>
import { ref, watch } from 'vue';

const props = defineProps({
    label:{
        type:String,
        default:""
    },
    modelValue:{
        type:Number,
    }
})

const emit = defineEmits(['update:modelValue']);
const typeValue = ref(props.model)

watch(typeValue, (newValue) => {
  emit('update:modelValue', newValue);
});

</script>

<template>
    <div class="flex flex-col">
        <label class="block mb-1 text-sm">{{ label }}</label>
        <select name="" id="" v-model="typeValue" class="w-full border p-2 rounded-md text-sm" required>
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
</template>