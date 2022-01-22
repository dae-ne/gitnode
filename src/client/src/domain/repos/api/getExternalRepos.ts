import { get } from 'infrastructure/persistence/axios';
import { RepoResponseDto } from '.';

export const getExternalRepos = (platform: string, account: string) =>
  get<RepoResponseDto[]>(`/repos/${platform}/${account}`);
