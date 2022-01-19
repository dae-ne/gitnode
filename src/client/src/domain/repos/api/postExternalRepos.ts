import { AxiosInstance } from 'axios';
import { RepoResponseDto } from '.';

export interface AddExternalReposRequestDto {
  account: string;
  platform: string;
  origin_ids: number[];
}

export const postExternalRepos = (
  axiosInstance: AxiosInstance,
  platform: string,
  account: string,
  originIds: number[],
): Promise<RepoResponseDto[]> => {
  const body: AddExternalReposRequestDto = { account, platform, origin_ids: originIds };
  return axiosInstance.post('/repos', body).then((response) => response.data);
};
