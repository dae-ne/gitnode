import { UsersRepository } from 'infrastructure/codegen';
import { useQuery } from 'react-query';
import { User } from '../..';

export const useGetUserQuery = () => {
  return useQuery('user', UsersRepository.getAuthenticatedUser, {
    cacheTime: 900,
    staleTime: 10000,
    select: (data): User => ({
      id: data.id,
      givenName: data.given_name,
      surname: data.surname,
      fullName: `${data.given_name} ${data.surname}`,
      email: data.email,
      avatarUrl: data.image_url,
      createdAt: new Date(data.created_at),
    }),
  });
};
