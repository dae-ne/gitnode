import React from 'react';
import { PageLayout } from 'application/layout/PageLayout';
import { HomePage, RepositoriesPage } from 'application/pages';
import { useRoutes } from 'react-router';

const routes = [
  {
    path: '/',
    element: <PageLayout />,
    children: [
      {
        path: '/',
        element: <HomePage />,
      },
      {
        path: '/repos',
        element: <RepositoriesPage />,
      },
    ],
  },
];

export const Router = () => {
  const routing = useRoutes(routes);
  return routing;
};
