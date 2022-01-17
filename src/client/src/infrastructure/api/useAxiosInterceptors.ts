import { useEffect } from 'react';
import { authState } from 'infrastructure/auth';
import { refreshToken as refresh } from 'infrastructure/auth';
import { useRecoilState } from 'recoil';
import { axiosClient } from './axiosClient';

export const useAxiosInterceptors = () => {
  const [auth, setAuth] = useRecoilState(authState);
  const { idToken, refreshToken } = auth;

  useEffect(() => {
    axiosClient.interceptors.request.use(
      (config) => {
        if (config.headers && idToken) config.headers.Authorization = `Bearer ${idToken}`;
        return config;
      },
      (error) => Promise.reject(error),
    );

    axiosClient.interceptors.response.use(
      (response) => response,
      // eslint-disable-next-line space-before-function-paren
      async (error) => {
        const originalRequest = error.config;
        const status = error.response.status;

        if ((status === 401 || status === 403) && !originalRequest._retry && refreshToken) {
          originalRequest._retry = true;
          const response = await refresh(refreshToken);
          const { id_token } = response.data;
          setAuth({ ...auth, idToken: id_token });
        }

        return error;
      },
    );
  }, [idToken, refreshToken]);

  return axiosClient;
};
