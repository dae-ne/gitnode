import { get } from 'infrastructure/persistence/axios';
import { useQuery } from 'react-query';
import { Repo } from '..';

export interface RepoResponseDto {
  id?: number;
  origin_id: number;
  name: string;
  description: string;
  url: string;
  private: boolean;
  account: string;
}

const getRepos = () => get<RepoResponseDto[]>('/repos');

export const useGetReposQuery = () => {
  return useQuery('repos', getRepos, {
    cacheTime: 1000,
    staleTime: 5000,
    select: (data): Repo[] =>
      data.map((repo) => ({
        id: repo.id,
        originId: repo.origin_id,
        name: repo.name,
        description: repo.description,
        url: repo.url,
        isPrivate: repo.private,
        account: repo.account,
      })),
  });
};
