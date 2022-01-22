import { post } from 'infrastructure/persistence/axios';
import { AccountResponseDto } from '.';

export const postAccount = (code: string, platform: string): Promise<AccountResponseDto> => {
  const body = { code, platform };
  return post('/account', body);
};
