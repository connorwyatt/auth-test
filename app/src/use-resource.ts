import { useQuery, UseQueryResult } from '@tanstack/react-query'
import { authStore } from 'auth/auth-store'
import axios from 'axios'
import { parseISO } from 'date-fns'

export interface Resource {
  message: string
  timestamp: Date
}

export const useResource = (): UseQueryResult<Resource> =>
  useQuery(
    ['resource'],
    async () => {
      try {
        const response = await axios({
          method: 'get',
          url: '/api/resource',
        })

        return {
          message: response.data.message,
          timestamp: parseISO(response.data.timestamp),
        }
      } catch (error) {
        console.log(axios.isAxiosError(error), error)

        if (axios.isAxiosError(error) && error.response?.status === 401) {
          authStore.getState().setIsAuthenticated(false)
        }

        throw error
      }
    },
    {
      refetchInterval: 1000,
    },
  )
