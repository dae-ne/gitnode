import { get } from 'infrastructure/persistence/axios';
import { useQuery } from 'react-query';
import { User } from '..';

export interface UserResponseDto {
  id: string;
  given_name: string;
  surname: string;
  email: string;
  image_url: string;
  created_at: string;
}

const getUser = () => get<UserResponseDto>('./user');

export const useGetUserQuery = () => {
  return useQuery('user', () => getUser(), {
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
