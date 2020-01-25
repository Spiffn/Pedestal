<template>
  <div>
    <mini-gallery
      v-for="gallery in galleries"
      :key="gallery.name"
      :name="gallery.name"
      :tags="gallery.tags"
    >
    </mini-gallery>
  </div>
</template>

<script>
import MiniGallery from './MiniGallery.vue';

export default {
  components: {
    MiniGallery,
  },
  data: () => ({
    galleries: [
      {
        name: '3D Models',
        tags: ['free', 'auto', 'human', 'space', 'architecture', 'weapons', 'anime', 'tools'],
      },
      {
        name: 'Community Constructors',
        tags: ['quality', 'free', 'abs'],
      },
    ],
  }),
};
</script>
