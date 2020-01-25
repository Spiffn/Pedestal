<template>
  <v-card class="mb-3">
    <v-card-title>
      {{ name }}
      <v-spacer />
      <v-btn text small color="blue">See more</v-btn>
    </v-card-title>
    <v-card-text>
      <p class="text-left">Tags</p>
      <div class="horizontal-scroll">
        <div
          v-for="tag in tags"
          :key="tag"
          class="scroll-item tag-item"
        >
        <div>
          <v-avatar
          size="36"
          color="grey lighten-2" />
        </div>
        <p class="tag">
          {{ tag }}
        </p>
        </div>
      </div>
      <p class="text-left">Gallery</p>
      <div class="horizontal-scroll">
        <div
          v-for="i in 20"
          :key="i"
          class="scroll-item"
        >
          <div class="gallery-item mr-4"></div>
        </div>
      </div>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  props: {
    name: {
      type: String,
      default: 'Title',
    },
    tags: {
      type: Array,
      default: () => [],
    },
  },
};
</script>

<style lang="scss" scoped>
  .horizontal-scroll {
    display: flex;
    flex-wrap: nowrap;
    overflow-x: auto;
    -webkit-overflow-scrolling: touch;

    &::-webkit-scrollbar {
      display: none;
    }
  }

  .scroll-item{
    flex: 0 0 auto;
  }

  .tag{
    font-size: 10px;
  }

  .tag-item {
    width: 70px;
  }

  .gallery-item {
    background-color: #dddddd;
    width: 100px;
    height: 100px;
    border-radius: 8px;
  }
</style>
