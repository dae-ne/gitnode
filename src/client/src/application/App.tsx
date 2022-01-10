import React from 'react';
import { HelmetProvider } from 'react-helmet-async';
import { Router } from './routing';

export const App = () => {
  return (
    <HelmetProvider>
      <Router />
    </HelmetProvider>
  );
};
