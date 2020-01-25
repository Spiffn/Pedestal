<template>
  <v-app-bar
    app
    hide-on-scroll
    flat
  >
    <v-app-bar-nav-icon></v-app-bar-nav-icon>
    <v-toolbar-title>{{ appName }}</v-toolbar-title>
    <v-spacer />
    <v-btn icon>
      <v-icon>mdi-account-circle-outline</v-icon>
    </v-btn>
    <v-btn icon>
      <v-icon>mdi-cart-outline</v-icon>
    </v-btn>
  </v-app-bar>
</template>

<script>
export default {
  data: () => ({
    appName: 'Spiffn',
  }),
};
</script>
