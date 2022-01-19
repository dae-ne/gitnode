import { AxiosInstance } from 'axios';
import { AccountResponseDto } from '.';

export const postAccount = (
  axiosInstance: AxiosInstance,
  code: string,
  platform: string,
): Promise<AccountResponseDto> => {
  const body = { code, platform };
  return axiosInstance.post('/account', body).then((response) => response.data);
};
