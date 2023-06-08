<template>
  <PersonEdit />
  <PersonList msg="Welcome to Your Vue.js App" />
</template>

<script>
import PersonEdit from './components/PersonEdit.vue'
import PersonList from './components/PersonList.vue'

export default {
  name: 'App',
  components: {
    PersonEdit,
    PersonList
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
