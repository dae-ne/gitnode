import range from 'lodash/range';
import { Account } from './Account';

export const userAccountsMock: Account[] = range(3).map((key) => ({
  id: key,
  originId: key.toString(),
  userId: key.toString(),
  platform: 'GitHub',
  name: 'Rafał Czajka',
  login: 'derav123',
  url: 'https://github.com/derav',
  avatarUrl: 'https://eu.ui-avatars.com/api/?name=Rafał+Czajka',
}));
