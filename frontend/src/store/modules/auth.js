import Vue from "vue";
import Vuex from "vuex";
import router from "@/router";

Vue.use(Vuex);

export default {
  strict: true,
  namespaced: true,
  getters: {
    Authenticated: state => {
      return state.authenticated;
    }
  },
  state: {
    user: null,
    authenticated: false,
    error: null,
    loading: false
  },
  mutations: {
    SET_USER(state, payload) {
      state.user = payload;
    },
    REMOVE_USER(state) {
      state.user = null;
    },
    SET_AUTHENTICATED(state, payload) {
      state.authenticated = payload;
    },
    SET_ERROR(state, payload) {
      state.error = payload;
    },
    SET_LOADING(state, payload) {
      state.loading = payload;
    }
  },
  actions: {
    loginUser({ commit }, { email, password }) {
      commit("SET_LOADING", true);
      firebase
        .auth()
        .signInWithEmailAndPassword(email, password)
        .then(res => {
          const newUser = {
            id: res.user.uid,
            name: res.user.displayName,
            email: res.user.email,
            photoUrl: res.user.photoURL
          };

          commit("SET_USER", newUser);
          commit("SET_AUTHENTICATED", true);
          commit("SET_ERROR", null);
          commit("SET_LOADING", false);
          router.push("/");
        })
        .catch(error => {
          commit("SET_USER", null);
          commit("SET_AUTHENTICATED", false);
          commit("SET_ERROR", error.message);
          commit("SET_LOADING", false);
          router.push("/");
        });
    },
    registerUser({ commit }, { email, password }) {
      commit("SET_LOADING", true);
      firebase
        .auth()
        .createUserWithEmailAndPassword(email, password)
        .then(res => {
          const newUser = {
            id: res.user.uid,
            name: res.user.displayName,
            email: res.user.email,
            photoUrl: res.user.photoURL
          };
          commit("SET_LOADING", false);
          commit("SET_USER", newUser);
          commit("SET_AUTHENTICATED", true);
          commit("SET_ERROR", null);
          router.push("/");
        })
        .catch(error => {
          commit("SET_USER", null);
          commit("SET_AUTHENTICATED", false);
          commit("SET_ERROR", error.message);
          commit("SET_LOADING", false);
          router.push("/auth");
        });
    },
    setUser({ commit }, user) {
      const newUser = {
        id: user.uid,
        name: user.displayName,
        email: user.email,
        photoUrl: user.photoURL
      };
      commit("SET_USER", newUser);
      commit("SET_AUTHENTICATED", true);
      commit("SET_ERROR", null);
    },
    signOutUser({ commit }) {
      commit("SET_LOADING", true);
      firebase
        .auth()
        .signOut()
        .then(() => {
          commit("REMOVE_USER");
          commit("SET_AUTHENTICATED", false);
          commit("SET_ERROR", null);
          commit("SET_LOADING", false);
          router.push("/auth");
        })
        .catch(error => {
          commit("SET_USER", null);
          commit("SET_AUTHENTICATED", false);
          commit("SET_ERROR", error.message);
          commit("SET_LOADING", false);
          router.push("/auth");
        });
    }
  }
};
