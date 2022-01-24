import React from 'react';
import { Card } from 'ui';
import { AccountListItemCard } from '../internal/components';
import { useGetAccountsQuery } from '../internal/queries';
import './styles.less';

const { Grid } = Card;

export interface AccountsListCardProps {
  showHeader?: boolean;
}

export const AccountsListCard = ({ showHeader = true }: AccountsListCardProps) => {
  const { isLoading, data } = useGetAccountsQuery();

  const getHeaderTitle = () => {
    return showHeader ? 'Accounts' : undefined;
  };

  return (
    <Card
      className="accounts-list-card"
      title={getHeaderTitle()}
      bodyStyle={{ padding: 0 }}
      loading={isLoading}
    >
      {data?.map((account) => {
        const { id, login, avatarUrl, platform } = account;
        return (
          <Grid className="accounts-list-card__grid" key={id}>
            <AccountListItemCard
              id={id.toString()}
              avatarUrl={avatarUrl}
              login={login}
              origin={platform}
            />
          </Grid>
        );
      })}
    </Card>
  );
};
