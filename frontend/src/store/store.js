import Vue from "vue";
import Vuex from "vuex";

import AuthStore from "./modules/auth";
import ReservationStore from "./modules/reservation";

Vue.use(Vuex);

export default new Vuex.Store({
  strict: true,
  modules: {
    auth: AuthStore,
    reservation: ReservationStore
  }
});
