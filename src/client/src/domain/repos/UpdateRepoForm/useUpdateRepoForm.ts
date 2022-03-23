import { useParams } from 'react-router-dom';
import { useUpdateRepoQuery, useGetReposQuery } from '../internal/queries';

export const useUpdateRepoForm = () => {
  const { repoId } = useParams();

  if (!repoId) {
    throw new Error('Repo id was not provided');
  }

  const { isLoading: isGetLoading, data } = useGetReposQuery();
  const { isLoading: isSetLoading, mutate } = useUpdateRepoQuery(repoId);

  return {
    isLoading: isGetLoading || isSetLoading,
    onSubmit: mutate,
    data: data?.find((repo) => repo.id.toString() === repoId),
  };
};
