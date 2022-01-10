import React from 'react';
import { List } from 'antd';
import { Card, CardProps } from 'ui';
import { userReposMock } from '../_mock';
import { RepoListItem } from '../components';
import { Repo } from '../Repo';

export interface ReposListCardProps extends Pick<CardProps, 'extra'> {
  limit?: number;
}

export const ReposListCard = ({ extra, limit }: ReposListCardProps) => {
  const getData = () => (limit ? userReposMock.slice(0, limit) : userReposMock);

  return (
    <Card title="Repositories" extra={extra} bodyStyle={{ padding: 0 }}>
      <List<Repo>
        renderItem={(item) => <RepoListItem {...item} />}
        dataSource={getData()}
        size="large"
      />
    </Card>
  );
};
