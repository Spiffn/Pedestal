<template>
  <v-footer
    dark
    padless
  >
    <!-- <v-row>
      <v-col cols="12" class="pa-0"> -->
        <v-card
          flat
          tile
          class="lighten-1 text-center full-width"
        >
          <v-card-text>
            <v-btn
              v-for="icon in icons"
              :key="icon"
              class="mx-4"
              icon
            >
              <v-icon size="24px">{{ icon }}</v-icon>
            </v-btn>
          </v-card-text>

          <v-card-text class="pt-0">
            Spiffn is a peer-to-peer market of 3D model enthusiasts who seek to
            buy, sell, print, paint, and design 3D models.
          </v-card-text>

          <v-divider></v-divider>

          <v-card-text>
            {{ copyright }}
          </v-card-text>
        </v-card>

      <!-- </v-col>
    </v-row> -->
  </v-footer>
</template>

<script>
export default {
  data: () => ({
    icons: [
      'mdi-facebook',
      'mdi-twitter-circle',
      'mdi-instagram',
    ],
  }),
  computed: {
    copyright() {
      return `Spiffn © ${new Date().getFullYear()}`;
    },
  },
};
</script>

<style lang="scss" scoped>
  .full-width {
    width: 100%;
  }
</style>
