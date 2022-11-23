import { formatISO } from 'date-fns'
import React, { FC } from 'react'
import { useResource } from 'use-resource'

export const Resource: FC = () => {
  const { data: resource, isInitialLoading } = useResource()

  if (isInitialLoading) {
    return <div>Loading...</div>
  }

  if (resource == null) {
    return null
  }

  return (
    <div className='Stack'>
      <div>Message: {resource.message}</div>
      <div>Fetched at: {formatISO(resource.timestamp, { representation: 'complete' })}</div>
    </div>
  )
}
