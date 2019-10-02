<template>
  <v-app id="keep">
    <v-navigation-drawer v-model="drawer" fixed clipped class="grey lighten-4" app>
      <v-list dense class="grey lighten-4">
        <template v-for="(item, i) in items">
          <v-layout v-if="item.heading" :key="i" row align-center>
            <v-flex xs6>
              <v-subheader v-if="item.heading">{{ item.heading }}</v-subheader>
            </v-flex>
            <v-flex xs6 class="text-xs-right">
              <v-btn small flat>edit</v-btn>
            </v-flex>
          </v-layout>
          <v-divider v-else-if="item.divider" :key="i" dark class="my-3"></v-divider>
          <v-list-tile v-else :key="i" :to="item.url">
            <v-list-tile-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-tile-action>
            <v-list-tile-content>
              <v-list-tile-title class="grey--text">{{ item.text }}</v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
        </template>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar color="amber" app absolute clipped-left>
      <v-toolbar-side-icon @click.native="drawer = !drawer"></v-toolbar-side-icon>
      <span class="title ml-3 mr-5">
        instatables
        <span class="font-weight-light"></span>
      </span>
      <v-text-field solo-inverted flat hide-details label="Search" prepend-inner-icon="search"></v-text-field>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn flat>
          <v-avatar size="36" color>
            <v-icon>account_circle</v-icon>
          </v-avatar>
          &nbsp;user
        </v-btn>
        <!--<v-btn flat @click="$store.dispatch(`auth/signOutUser`)">
          <v-icon left dark>logout</v-icon>
        </v-btn>-->
      </v-toolbar-items>
    </v-toolbar>
    <v-content>
      <v-container fluid>
        <v-layout justify-center align-center>
          <v-flex>
            <router-view></router-view>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
export default {
  data: () => ({
    drawer: null,
    items: [
      { icon: "lightbulb_outline", text: "Home", url: "/" },
      { icon: "people", text: "Klanten", url: "/customers" },
      { icon: "touch_app", text: "Reserveringen", url: "/reservations" },
      { divider: true },
      { icon: "settings", text: "Instellingen" },
      { icon: "chat_bubble", text: "Prullenbak" },
      { icon: "help", text: "Help" }
    ]
  }),
  props: {
    source: String
  }
};
</script>