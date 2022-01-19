import { AxiosInstance } from 'axios';
import { RepoResponseDto } from '.';

export const getExternalRepos = (
  axiosInstance: AxiosInstance,
  platform: string,
  account: string,
): Promise<RepoResponseDto[]> => {
  return axiosInstance.get(`/repos/${platform}/${account}`).then((response) => response.data);
};
