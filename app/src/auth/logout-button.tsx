import { authStore } from 'auth/auth-store'
import axios from 'axios'
import { FC, useCallback } from 'react'

export const LogoutButton: FC = () => {
  const handleClick = useCallback(() => {
    const fn = async (): Promise<void> => {
      await axios({
        method: 'post',
        url: '/api/auth/logout',
      })

      authStore.getState().setIsAuthenticated(false)
    }

    fn().catch(() => null)
  }, [])

  return (
    <div>
      <button type='button' onClick={handleClick}>
        Log out
      </button>
    </div>
  )
}
