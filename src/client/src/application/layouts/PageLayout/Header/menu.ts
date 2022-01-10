import { PathNameType } from 'application/routing';

export interface MenuLink {
  text: string;
  path: PathNameType;
}

export const menuLinks: MenuLink[] = [
  {
    text: 'Home',
    path: '/',
  },
  {
    text: 'Repositories',
    path: '/repos',
  },
];
