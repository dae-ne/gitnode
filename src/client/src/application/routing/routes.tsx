import React from 'react';
import { BaseLayout, PageLayout } from 'application/layouts';
import {
  AccountPage,
  AccountsPage,
  HomePage,
  NewAccountPage,
  NewRepoPage,
  RepoPage,
  ReposPage,
} from 'application/pages';
import { RouteObject } from 'react-router';

export const ROUTER_PATHS = [
  '/',
  '/accounts',
  '/accounts/:accountId',
  '/accounts/new',
  '/repos',
  '/repos/:repoId',
  '/repos/new',
  '/404',
  '*',
] as const;

export type PathNameType = typeof ROUTER_PATHS[number];

interface Routes extends Omit<RouteObject, 'path' | 'children'> {
  path: PathNameType;
  children?: Routes[];
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
            path: '/accounts',
            element: <AccountsPage title="accounts" />,
          },
          {
            path: '/accounts/:accountId',
            element: <AccountPage title="account" />,
          },
          {
            path: '/accounts/new',
            element: <NewAccountPage title="new account" />,
          },
          {
            path: '/repos',
            element: <ReposPage title="repos" />,
          },
          {
            path: '/repos/:repoId',
            element: <RepoPage title="repo" />,
          },
          {
            path: '/repos/new',
            element: <NewRepoPage title="new repo" />,
          },
        ],
      },
      {
        path: '/404',
        element: <div>404</div>,
      },
      {
        path: '*',
        element: <div>404</div>,
      },
    ],
  },
];
