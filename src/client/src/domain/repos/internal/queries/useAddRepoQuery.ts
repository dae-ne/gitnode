import { AddRepoRequestDto, ReposRepository } from 'infrastructure/codegen';
import { useMutation } from 'react-query';

export const useAddRepoQuery = () => {
  return useMutation('repos', (body: AddRepoRequestDto) => ReposRepository.addRepo(body));
};
