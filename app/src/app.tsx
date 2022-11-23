import { LoginButton } from 'auth/login-button'
import { LogoutButton } from 'auth/logout-button'
import { useAuthStore } from 'auth/use-auth-store'
import React, { FC } from 'react'
import { Resource } from 'resource'
import 'app.css'

export const App: FC = () => {
  const { isAuthenticated } = useAuthStore()

  return (
    <div className='Stack'>
      {isAuthenticated ? <LogoutButton /> : <LoginButton />}
      {isAuthenticated && <Resource />}
    </div>
  )
}
