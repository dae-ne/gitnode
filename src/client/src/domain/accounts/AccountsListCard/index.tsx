import React from 'react';
import { Card } from 'ui';
import { userAccountsMock } from '../_mock';
import { AccountListItemCard } from '../components';
import './styles.less';

const { Grid } = Card;

export const AccountsListCard = () => {
  return (
    <Card className="accounts-list-card" title="Accounts" bodyStyle={{ padding: 0 }}>
      {userAccountsMock.map((account) => {
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
