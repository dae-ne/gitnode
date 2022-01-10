import range from 'lodash/range';
import { Repo } from './Repo';

export const userReposMock: Repo[] = range(10).map((key) => ({
  id: key,
  originId: key,
  name: 'reponame',
  description:
    // eslint-disable-next-line max-len
    'Nulla lobortis laoreet eros, a tincidunt ipsum pharetra quis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.',
  url: 'https://github.com/derav',
  isPrivate: false,
  account: 'derav',
}));
