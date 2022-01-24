import { AccountsRepository } from 'infrastructure/codegen';
import { useQuery } from 'react-query';
import { Account } from '../..';

export const useGetAccountsQuery = () => {
  return useQuery('accounts', AccountsRepository.getAccounts, {
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
