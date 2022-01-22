import { get } from 'infrastructure/persistence/axios';
import { useQuery } from 'react-query';
import { Account } from '..';

export interface AccountResponseDto {
  id: number;
  origin_id: string;
  user_id: string;
  platform: string;
  login: string;
  url: string;
  avatar_url: string;
}

const getAccounts = (): Promise<AccountResponseDto[]> => get<AccountResponseDto[]>('/accounts');

export const useGetAccountsQuery = () => {
  return useQuery('accounts', getAccounts, {
    cacheTime: 1000,
    staleTime: 5000,
    select: (data): Account[] =>
      data.map((account) => ({
        id: account.id,
        originId: account.origin_id,
        userId: account.user_id,
        platform: account.platform,
        login: account.login,
        url: account.url,
        avatarUrl: account.avatar_url,
      })),
  });
};
