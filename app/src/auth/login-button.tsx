import { authStore } from 'auth/auth-store'
import axios from 'axios'
import { FC, useCallback } from 'react'

export const LoginButton: FC = () => {
  const handleClick = useCallback(() => {
    const fn = async (): Promise<void> => {
      await axios({
        method: 'post',
        url: '/api/auth/login',
      })

      authStore.getState().setIsAuthenticated(true)
    }

    fn().catch(() => null)
  }, [])

  return (
    <div>
      <button type='button' onClick={handleClick}>
        Log in
      </button>
    </div>
  )
}
