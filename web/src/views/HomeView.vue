<script setup lang="ts">
import { ref } from 'vue';
import axios from 'axios';

const result = ref(null)

function onClick () {
  axios.get('https://localhost:7076/Test').then((data) =>
  {
    console.log(data.data)
    result.value = data.data
  })
}

</script>

<template>
  <div>
    <div class="border">
      {{ result }}
    </div>
    <button @click="onClick()">取得資料</button>
  </div>
</template>

<style scoped>
.border {
  border: 1px solid #000;
}
</style>  