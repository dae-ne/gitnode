import React from 'react';
import { BaseLayout, PageLayout } from 'application/layouts';
import { HomePage, ReposPage } from 'application/pages';
import { RouteObject } from 'react-router';

export const ROUTER_PATHS = ['/', '/repos', '/accounts', '/settings'] as const;

export type PathNameType = typeof ROUTER_PATHS[number];

export interface Routes extends Omit<RouteObject, 'path'> {
  path: PathNameType;
}

export const routes: Routes[] = [
  {
    path: '/',
    element: <BaseLayout />,
    children: [
      {
        path: '/',
        element: <PageLayout />,
        children: [
          {
            path: '/',
            element: <HomePage title="home" />,
          },
          {
            path: '/repos',
            element: <ReposPage />,
          },
        ],
      },
    ],
  },
];
