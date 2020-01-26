<template>
  <v-app>
    <app-navbar v-model="navbarOpen" />
    <v-content>
      <app-toolbar @open="navbarOpen = !navbarOpen" />
      <v-container fluid>
        <slot></slot>
      </v-container>
    </v-content>

    <app-footer />
  </v-app>
</template>

<script>
import AppFooter from './AppFooter.vue';
import AppNavbar from './AppNavbar.vue';
import AppToolbar from './AppToolbar.vue';

export default {
  components: {
    AppFooter,
    AppNavbar,
    AppToolbar,
  },
  data: () => ({
    navbarOpen: null,
  }),
};
</script>
