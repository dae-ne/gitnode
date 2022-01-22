import React, { useEffect } from 'react';
import { authState, getTokens } from 'infrastructure/auth';
import { useAxiosInterceptors } from 'infrastructure/persistence/axios';
import { HelmetProvider } from 'react-helmet-async';
import { QueryClient, QueryClientProvider } from 'react-query';
import { useSetRecoilState } from 'recoil';
import { Router } from './routing';
import 'antd/dist/antd.css';
import './global.less';

const queryClient = new QueryClient();

export const App = () => {
  const setAuth = useSetRecoilState(authState);
  useAxiosInterceptors();

  useEffect(() => {
    const auth = getTokens();
    auth && setAuth(auth);
  }, []);

  return (
    <HelmetProvider>
      <QueryClientProvider client={queryClient}>
        <Router />
      </QueryClientProvider>
    </HelmetProvider>
  );
};
