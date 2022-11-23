import create from 'zustand/vanilla'

export interface AuthStore {
  isAuthenticated: boolean
  setIsAuthenticated: (isAuthenticated: boolean) => void
}

export const authStore = create<AuthStore>((set) => ({
  isAuthenticated: true,
  setIsAuthenticated: (isAuthenticated: boolean) => set({ isAuthenticated }),
}))
