import React from 'react';
import { HelmetProvider } from 'react-helmet-async';
import { QueryClient, QueryClientProvider } from 'react-query';
import { RecoilRoot } from 'recoil';
import { Router } from './routing';
import 'antd/dist/antd.css';
import './global.less';

const queryClient = new QueryClient();

export const App = () => {
  return (
    <HelmetProvider>
      <RecoilRoot>
        <QueryClientProvider client={queryClient}>
          <Router />
        </QueryClientProvider>
      </RecoilRoot>
    </HelmetProvider>
  );
};
