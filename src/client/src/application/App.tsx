import React from 'react';
import { HelmetProvider } from 'react-helmet-async';
import { Router } from './routing';
import 'antd/dist/antd.css';
import './global.less';

export const App = () => {
  return (
    <HelmetProvider>
      <Router />
    </HelmetProvider>
  );
};
