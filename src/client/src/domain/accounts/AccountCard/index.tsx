import React from 'react';
import { LinkOutlined } from '@ant-design/icons';
import { Divider } from 'antd';
import { Card, UserInfo } from 'ui';
import { useGetAccountsQuery } from '../internal/queries';
import './styles.less';

export interface AccountCardProps {
  accountId: number;
}

export const AccountCard = ({ accountId }: AccountCardProps) => {
  const { isLoading, data } = useGetAccountsQuery();
  const account = data?.find((a) => a.id === accountId);

  if (!account) {
    return <></>;
  }

  const { platform, login, url, avatarUrl } = account;

  return (
    <Card className="account-card" loading={isLoading}>
      <UserInfo size="large" name={login} imageUrl={avatarUrl} origin={platform} />
      <Divider dashed />
      <a href={url} target="_blank" rel="noreferrer">
        <LinkOutlined className="account-card__link-icon" />
        {url}
      </a>
    </Card>
  );
};
