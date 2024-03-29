import React from 'react';
import { List } from 'antd';
import { Card, CardProps } from 'ui';
import { Repo } from '..';
import { RepoListItem } from '../internal/components';
import { useReposListCard } from './useReposListCard';

export interface ReposListCardProps extends Pick<CardProps, 'extra'> {
  limit?: number;
  accountId?: number;
}

export const ReposListCard = ({ extra, limit, accountId }: ReposListCardProps) => {
  const { isLoading, data } = useReposListCard(limit, accountId);

  return (
    <Card title="Repositories" extra={extra} loading={isLoading} bodyStyle={{ padding: 0 }}>
      {data && (
        <List<Repo>
          renderItem={(item) => {
            const { id, owner, ...rest } = item;
            return id ? (
              <RepoListItem
                id={id}
                account={owner.login}
                accountAvatarUrl={owner.avatarUrl}
                {...rest}
              />
            ) : undefined;
          }}
          dataSource={data}
          size="large"
        />
      )}
    </Card>
  );
};
