import { AxiosInstance } from 'axios';
import { useAxiosInterceptors } from 'infrastructure/api';
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

const getUser = (axiosInstance: AxiosInstance): Promise<UserResponseDto> => {
  return axiosInstance.get('/user').then((response) => response.data);
};

export const useGetUserQuery = () => {
  const axios = useAxiosInterceptors();

  return useQuery('user', () => getUser(axios), {
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
