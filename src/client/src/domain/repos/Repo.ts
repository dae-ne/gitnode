import { RepoOwner } from './RepoOwner';

export interface Repo {
  id: number;
  originId: number;
  name: string;
  description?: string;
  url: string;
  isPrivate: boolean;
  owner: RepoOwner;
}
