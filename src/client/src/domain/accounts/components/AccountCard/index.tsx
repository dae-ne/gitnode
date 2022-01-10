import React from 'react';
import { Avatar } from 'antd';
import { Card, CardProps } from 'ui';

const { Meta } = Card;

export interface AccountCardProps extends CardProps {
  avatarUrl?: string;
  login: string;
}

export const AccountCard = ({ avatarUrl, login }: AccountCardProps) => {
  return (
    <Card bodyStyle={{ padding: 0 }}>
      <Meta
        title={
          <div>
            {avatarUrl && <Avatar size="small" src={avatarUrl} />}
            <p>{login}</p>
          </div>
        }
      />
    </Card>
  );
};
