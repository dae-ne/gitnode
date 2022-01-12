import React from 'react';
import { Card, CardProps, UserInfo } from 'ui';

const { Meta } = Card;

export interface AccountCardProps extends CardProps {
  avatarUrl: string;
  login: string;
  origin: string;
}

export const AccountCard = ({ avatarUrl, login, origin }: AccountCardProps) => {
  return (
    <Card bodyStyle={{ padding: 0 }}>
      <Meta title={<UserInfo size="medium" name={login} imageUrl={avatarUrl} origin={origin} />} />
    </Card>
  );
};
