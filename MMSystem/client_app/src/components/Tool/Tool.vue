<template>
  <div class="tool" >
    <div @click="event">
      <i :class="iconClass"></i>
    </div>
    <!-- <div v-if="labelForUploadImage" :class="{ 'upload-image': labelForUploadImage,'tool': labelForUploadImage}">
      <label for="chooseImage"><i :class="iconClass"></i></label>
      <input
        id="chooseImage"
        style="visibility:hidden;"
        type="file"
        @change="event"
        accept="image/*"
      />
    </div> -->
  <!--  props: ["event", "iconClass", "labelForUploadImage"],
     -->
  </div>
</template>

<script>    
export default {
  name: "tool",
  props: ["event", "iconClass"],
};
</script>

<style scoped>

  .tool {
  align-items: center;
  justify-content: space-between;
  display: flex;
  font-size: 16px;
  padding: 2px 5px;
  
 
}
.tool:hover {
    cursor: pointer;
    color: #4287f5;
  }

.upload-image {
    max-width: 15px;
  }


</style>
