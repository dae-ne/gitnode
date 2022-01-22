import { post } from 'infrastructure/persistence/axios';
import { RepoResponseDto } from '.';

export interface AddExternalReposRequestDto {
  account: string;
  platform: string;
  origin_ids: number[];
}

export const postExternalRepos = (
  platform: string,
  account: string,
  originIds: number[],
): Promise<RepoResponseDto[]> => {
  const body: AddExternalReposRequestDto = { account, platform, origin_ids: originIds };
  return post('/repos', body);
};
