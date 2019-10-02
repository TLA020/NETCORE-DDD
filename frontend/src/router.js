import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";

Vue.use(Router);

const router = new Router({
    routes: [
        {
            path: "/",
            name: "Home",
            component: Home,
            meta: {
                authRequired: true
            }
        },
        {
            path: "/customers",
            name: "Klanten",
            component: () => import("./views/CustomerList.vue"),
            meta: {
                authRequired: true
            }
        },
        {
            path: "/reservations",
            name: "Reservations",
            component: () => import("./views/TimeTable.vue"),
            meta: {
                authRequired: true
            }
        }
    ]
});

// router.beforeEach((to, from, next) => {
//   if (to.matched.some(record => record.meta.authRequired)) {
//     if (!store.getters["auth/Authenticated"]) {
//       firebase.auth().onAuthStateChanged(user => {
//         if (!user) {
//           next({ path: "/auth" });
//         }
//         store.dispatch("auth/setUser", user);
//         next();
//       });
//     } else {
//       next();
//     }
//   } else {
//     next();
//   }
// });

export default router;
