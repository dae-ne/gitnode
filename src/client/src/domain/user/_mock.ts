import { User } from './model';

export const authenticatedUserMock: User = {
  id: '123',
  givenName: 'Rafał',
  surname: 'Czajka',
  email: 'rafal.czajka@mock.com',
  imageUrl: 'https://eu.ui-avatars.com/api/?name=Rafał+Czajka',
  createdAt: new Date(),
};
