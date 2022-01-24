import React from 'react';
import { List } from 'antd';
import { Card, CardProps } from 'ui';
import { Repo } from '..';
import { RepoListItem } from '../internal/components';
import { useReposListCard } from './useReposListCard';

export interface ReposListCardProps extends Pick<CardProps, 'extra'> {
  limit?: number;
}

export const ReposListCard = ({ extra, limit }: ReposListCardProps) => {
  const { isLoading, data } = useReposListCard();

  return (
    <Card title="Repositories" extra={extra} loading={isLoading} bodyStyle={{ padding: 0 }}>
      {data && (
        <List<Repo>
          renderItem={(item) => {
            const { id, owner, ...rest } = item;
            return id ? <RepoListItem id={id} account={owner.login} {...rest} /> : undefined;
          }}
          dataSource={limit ? data.slice(0, limit) : data}
          size="large"
        />
      )}
    </Card>
  );
};
