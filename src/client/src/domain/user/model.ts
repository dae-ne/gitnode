export interface User {
  id: string;
  givenName: string;
  surname: string;
  email: string;
  imageUrl?: string;
  createdAt: Date;
}
