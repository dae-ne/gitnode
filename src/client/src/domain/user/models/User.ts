export interface User {
  id: string;
  givenName: string;
  surname: string;
  email: string;
  avatarUrl?: string;
  createdAt: Date;
}
