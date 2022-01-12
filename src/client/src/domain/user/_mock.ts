import { User } from './User';

export const authenticatedUserMock: User = {
  id: '123',
  givenName: 'Rafał',
  surname: 'Czajka',
  email: 'rafal.czajka@mock.com',
  avatarUrl: 'https://eu.ui-avatars.com/api/?name=Rafał+Czajka',
  createdAt: new Date(),
};
