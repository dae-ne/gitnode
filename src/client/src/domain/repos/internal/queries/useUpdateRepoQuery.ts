import { Repo } from 'domain/repos';
import { ReposRepository, UpdateRepoRequestDto } from 'infrastructure/codegen';
import { useMutation, useQueryClient } from 'react-query';

export const useUpdateRepoQuery = (idStr: string) => {
  const id = parseInt(idStr);
  const queryClient = useQueryClient();
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  return useMutation<any, any, any, any>(
    (body: UpdateRepoRequestDto) => ReposRepository.updateRepo(id, body),
    {
      onMutate: async (updatedRepo) => {
        await queryClient.cancelQueries('repos');
        const previousData = queryClient.getQueryData<Repo[]>('repos');
        if (previousData) {
          queryClient.setQueryData<Repo[]>('repos', (prev) => {
            if (!prev) return [];

            const oldRepo = prev.find((repo) => repo.id === id);

            if (!oldRepo) return prev;

            const newRepo: Repo = {
              ...oldRepo,
              name: updatedRepo.name ?? oldRepo.name,
              description: updatedRepo.description ?? oldRepo.description,
              isPrivate: updatedRepo.private ?? oldRepo.isPrivate,
            };

            return [...prev, newRepo];
          });
        }
      },
      onError: (_err, _variables, context) => {
        if (context?.previousTodos) {
          queryClient.setQueryData<Repo[]>('repos', context.previousTodos);
        }
      },
      onSettled: () => {
        queryClient.invalidateQueries('repos');
      },
    },
  );
};
