import { useState } from 'react';
import { axiosClient } from 'infrastructure/api';
import { useRecoilState } from 'recoil';
import { TokenResponseDto } from './authApi';
import { authState } from './authState';

export const useAuthenticate = (code: string) => {
  const [isLoading, setIsLoading] = useState(true);
  const [auth, setAuth] = useRecoilState(authState);

  const body = { code, grant_type: 'authorization_code' };

  axiosClient.post<TokenResponseDto>('/auth/token', body).then((response) => {
    const { id_token: idToken, refresh_token: refreshToken } = response.data;
    setAuth({
      idToken,
      refreshToken,
    });
    setIsLoading(false);
  });

  return [auth, isLoading];
};
