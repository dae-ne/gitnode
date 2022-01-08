import React from 'react';
import { PageLayout } from 'application/layout';
import { HomePage, RepositoriesPage } from 'application/pages';
import { RouteObject } from 'react-router';

export const ROUTER_PATHS = ['/', '/repos', '/accounts', '/settings'] as const;

export type PathNameType = typeof ROUTER_PATHS[number];

export interface Routes extends Omit<RouteObject, 'path'> {
  path: PathNameType;
}

export const routes: Routes[] = [
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
