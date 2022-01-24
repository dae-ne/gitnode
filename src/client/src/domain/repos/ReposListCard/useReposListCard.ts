import { useEffect, useState } from 'react';
import { ReposRepository } from 'infrastructure/codegen';
import { useGetReposQuery } from '../internal/queries';

export const useReposListCard = () => {
  const [fetchLoading, setFetchLoading] = useState(true);
  const { isLoading, data, refetch } = useGetReposQuery();

  useEffect(() => {
    async function fetchExternalRepos() {
      const href = window.location.href;
      const url = href ? new URL(href) : undefined;
      const platform = url?.searchParams.get('platform');
      const login = url?.searchParams.get('login');

      if (!platform || !login) {
        setFetchLoading(false);
        return;
      }

      const externalRepos = await ReposRepository.getExternalRepos(platform, login);
      const ids = externalRepos.map((repo) => repo.origin_id);
      await ReposRepository.addMultipleRepos({ account: login, platform, origin_ids: ids });
      await refetch();
      setFetchLoading(false);
    }
    fetchExternalRepos();
  }, []);

  return { isLoading: isLoading || fetchLoading, data };
};
