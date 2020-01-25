<template>
  <v-app>
    <!-- <v-navigation-drawer app>
    </v-navigation-drawer> -->
    <v-content>
      <app-toolbar/>
      <v-container fluid>
        <slot></slot>
      </v-container>
    </v-content>

    <app-footer />
  </v-app>
</template>

<script>
import AppFooter from './AppFooter.vue';
import AppToolbar from './AppToolbar.vue';

export default {
  components: {
    AppFooter,
    AppToolbar,
  },
};
</script>
