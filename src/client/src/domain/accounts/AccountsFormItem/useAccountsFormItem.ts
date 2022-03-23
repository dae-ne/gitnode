import { Account } from '..';
import { useGetAccountsQuery } from '../internal/queries';

const filterData = (data: Account[], platform?: string) => {
  const platformName = platform?.toLowerCase();
  return data.filter((account) => account.platform.toLowerCase() === platformName);
};

export const useAccountsFormItem = (platform?: string) => {
  const { isLoading, data } = useGetAccountsQuery();

  return {
    isLoading,
    data: data ? filterData(data, platform) : [],
  };
};
