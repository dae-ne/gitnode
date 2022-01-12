export interface Account {
  id: number;
  originId: string;
  userId: string;
  platform: string;
  name?: string;
  login: string;
  url: string;
  avatarUrl: string;
}
