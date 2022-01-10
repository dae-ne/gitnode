import React from 'react';
import { Card } from 'ui';
import { userAccountsMock } from '../_mock';
import { AccountCard } from '../components';
import './styles.less';

const { Grid } = Card;

export const AccountsListCard = () => {
  return (
    <Card className="accounts-list-card" title="Accounts" bodyStyle={{ padding: 0 }}>
      {userAccountsMock.map((account) => {
        const { id, login, avatarUrl } = account;
        return (
          <Grid className="accounts-list-card__grid" key={id}>
            <AccountCard avatarUrl={avatarUrl} login={login} />
          </Grid>
        );
      })}
    </Card>
  );
};
