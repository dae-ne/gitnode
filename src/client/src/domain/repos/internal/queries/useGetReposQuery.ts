import { ReposRepository } from 'infrastructure/codegen';
import { useQuery } from 'react-query';
import { Repo } from '../..';

export const useGetReposQuery = () => {
  return useQuery('repos', ReposRepository.getRepos, {
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
        owner: {
          id: repo.owner.id,
          login: repo.owner.login,
          url: repo.owner.url,
          avatarUrl: repo.owner.avatar_url,
        },
      })),
  });
};
