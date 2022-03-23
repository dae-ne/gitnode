import { useEffect } from 'react';
import { authState, deleteTokens, saveTokens } from 'infrastructure/auth';
import { AuthRepository } from 'infrastructure/codegen';
import { useRecoilState } from 'recoil';
import { axiosConfig } from './axiosConfig';

export const useAxiosInterceptors = () => {
  const [auth, setAuth] = useRecoilState(authState);
  const { idToken, refreshToken } = auth;

  useEffect(() => {
    // TODO: change type
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const handleUnauthenticated = async (originalRequest: any, token: string) => {
      originalRequest._retry = true;
      const { id_token } = await AuthRepository.getToken({
        refresh_token: token,
        grant_type: 'refresh_token',
      });
      setAuth({ ...auth, idToken: id_token });
      saveTokens({ idToken: id_token, refreshToken: auth.refreshToken });
      axiosConfig.defaults.headers.common.Authorization = `Bearer ${id_token}`;
      return axiosConfig(originalRequest);
    };

    // TODO: change type
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const handleFinalResponse = (error: any) => {
      setAuth({});
      deleteTokens();
      return error;
    };

    axiosConfig.interceptors.request.use(
      (config) => {
        if (config.headers && idToken) config.headers.Authorization = `Bearer ${idToken}`;
        return config;
      },
      (error) => Promise.reject(error),
    );

    axiosConfig.interceptors.response.use(
      (response) => response,
      async (error) => {
        const originalRequest = error.config;
        const status = error.response.status;

        return refreshToken && (status === 401 || status === 403) && !originalRequest._retry
          ? handleUnauthenticated(originalRequest, refreshToken)
          : Promise.reject(handleFinalResponse(error));
      },
    );
  }, [idToken, refreshToken]);
};
