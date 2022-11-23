import { authStore } from 'auth/auth-store'
import create from 'zustand'

export const useAuthStore = create(authStore)
