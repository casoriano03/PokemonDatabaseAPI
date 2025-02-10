import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PokemonView from '@/views/PokemonView.vue'
import LoginView from '@/views/LoginView.vue'
import RegisterView from '@/views/RegisterView.vue'
import ProfleView from '@/views/ProfleView.vue'
import PokemonDataView from '@/views/PokemonDataView.vue'
import AdminView from '@/views/AdminView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/pokemon',
      name: 'pokemon',
      component: PokemonView,
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView,
    },
    {
      path: '/profile',
      name: 'profile',
      component: ProfleView,
      meta: { requiresAuth: true },
    },
    {
      path: '/pokemon/:id',
      name: 'pokemonData',
      component: PokemonDataView,
    },
    {
      path: '/admin',
      name: 'admin',
      component: AdminView,
    },

  ],
})

router.beforeEach((to, from, next) => {
  const isAuthenticated = sessionStorage.getItem("authToken");

  if (to.meta.requiresAuth && !isAuthenticated) {
    next("/login");
  } else {
    next();
  }
});

export default router
