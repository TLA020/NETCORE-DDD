import Vue from 'vue'
import 'es6-promise/auto'
import Vuex from 'vuex'
import Vuetify from 'vuetify'
import './plugins/vuetify'
import App from './App.vue'
import colors from 'vuetify/es5/util/colors'
import router from './router'
import store from './store/store'
import '@fortawesome/fontawesome-free/css/all.css'
import 'material-design-icons-iconfont/dist/material-design-icons.css'

Vue.config.productionTip = false

Vue.use(Vuex);

Vue.use(Vuetify, {
  iconfont: 'md',
  theme: {
    primary: colors.purple,
    secondary: colors.grey.darken1,
    accent: colors.shades.black,
    error: colors.red.accent3
  }
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
