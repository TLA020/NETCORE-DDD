import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default {
  strict: true,
  namespaced: true,
  getters: {
    Reservations: state => {
      return state.reservations;
    }
  },
  state: {
    error: null,
    loading: false
  },
  mutations: {
    SET_ERROR(state, payload) {
      state.error = payload;
    },
    SET_LOADING(state, payload) {
      state.loading = payload;
    }
  },
  actions: {
    updateReservation({ commit }, reservation) {
      commit("SET_LOADING", true);
      db.collection("reservations")
        .doc(reservation[".key"])
        .update({
          name: reservation.name | "",
          amount: reservation.amount | "",
          time: reservation.time | "",
          remark: reservation.remark | ""
        });

      commit("SET_ERROR", null);
      commit("SET_LOADING", false);
    },
    addReservation({ commit }, reservation) {
      commit("SET_LOADING", true);
      db.collection("reservations").add({
        ...reservation,
        timestamp: new Date()
      });
      commit("SET_ERROR", null);
      commit("SET_LOADING", false);
    },
    deleteReservation({ commit }, reservation) {
      commit("SET_LOADING", true);
      db.collection("reservations")
        .doc(reservation[".key"])
        .delete();
      commit("SET_LOADING", false);
    }
  }
};
