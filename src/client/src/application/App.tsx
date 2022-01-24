import React from 'react';
import { useAxiosInterceptors } from 'infrastructure/axios';
import { HelmetProvider } from 'react-helmet-async';
import { QueryClient, QueryClientProvider } from 'react-query';
import { Router } from './routing';
import 'antd/dist/antd.css';
import './global.less';

const queryClient = new QueryClient();

export const App = () => {
  useAxiosInterceptors();

  return (
    <HelmetProvider>
      <QueryClientProvider client={queryClient}>
        <Router />
      </QueryClientProvider>
    </HelmetProvider>
  );
};
