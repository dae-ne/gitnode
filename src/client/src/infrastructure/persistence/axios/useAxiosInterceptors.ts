import { useEffect } from 'react';
import { authState } from 'infrastructure/auth';
import { refreshToken as refresh } from 'infrastructure/auth';
import { useRecoilState } from 'recoil';
import { axios } from './axios';

export const useAxiosInterceptors = () => {
  const [auth, setAuth] = useRecoilState(authState);
  const { idToken, refreshToken } = auth;

  useEffect(() => {
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const handleUnauthenticated = async (originalRequest: any, token: string) => {
      originalRequest._retry = true;
      const { id_token } = await refresh(token);
      setAuth({ ...auth, idToken: id_token });
      axios.defaults.headers.common.Authorization = `Bearer ${id_token}`;
      return axios(originalRequest);
    };

    axios.interceptors.request.use(
      (config) => {
        if (config.headers && idToken) config.headers.Authorization = `Bearer ${idToken}`;
        return config;
      },
      (error) => Promise.reject(error),
    );

    axios.interceptors.response.use(
      (response) => response,
      async (error) => {
        const originalRequest = error.config;
        const status = error.response.status;

        return refreshToken && (status === 401 || status === 403) && !originalRequest._retry
          ? handleUnauthenticated(originalRequest, refreshToken)
          : Promise.reject(error);
      },
    );
  }, [idToken, refreshToken]);
};
