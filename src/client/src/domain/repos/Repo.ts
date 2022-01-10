export interface Repo {
  id: number;
  originId: number;
  name: string;
  description: string;
  url: string;
  isPrivate: boolean;
  account: string;
}
