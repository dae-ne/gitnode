import React from 'react';
import { LinkOutlined } from '@ant-design/icons';
import { Divider } from 'antd';
import { Card, UserInfo } from 'ui';
import { userAccountsMock } from '../_mock';
import './styles.less';

export interface AccountCardProps {
  accountId: string;
}

export const AccountCard = ({ accountId }: AccountCardProps) => {
  const account = userAccountsMock.find((a) => a.id.toString() === accountId);

  if (!account) {
    return <></>;
  }

  const { platform, login, url, avatarUrl } = account;

  return (
    <Card className="account-card">
      <UserInfo size="large" name={login} imageUrl={avatarUrl} origin={platform} />
      <Divider dashed />
      <a href={url} target="_blank" rel="noreferrer">
        <LinkOutlined className="account-card__link-icon" />
        {url}
      </a>
    </Card>
  );
};
