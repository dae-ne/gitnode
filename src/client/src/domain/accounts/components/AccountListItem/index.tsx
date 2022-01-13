import React from 'react';
import { Link } from 'react-router-dom';
import { Card, CardProps, UserInfo } from 'ui';

const { Meta } = Card;

export interface AccountListItemProps extends CardProps {
  avatarUrl: string;
  login: string;
  origin: string;
}

export const AccountListItemCard = ({ id, avatarUrl, login, origin }: AccountListItemProps) => {
  return (
    <Card bodyStyle={{ padding: 0 }}>
      <Meta
        title={
          <UserInfo
            size="medium"
            name={<Link to={`/accounts/${id}`}>{login}</Link>}
            imageUrl={avatarUrl}
            origin={origin}
          />
        }
      />
    </Card>
  );
};
