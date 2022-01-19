import React, { useEffect } from 'react';
import { List } from 'antd';
import { useAxiosInterceptors } from 'infrastructure/api';
import { Card, CardProps } from 'ui';
import { getExternalRepos, postExternalRepos, useGetReposQuery } from '../api';
import { RepoListItem } from '../components';
import { Repo } from '../Repo';

export interface ReposListCardProps extends Pick<CardProps, 'extra'> {
  limit?: number;
}

export const ReposListCard = ({ extra, limit }: ReposListCardProps) => {
  const { isLoading, data, refetch } = useGetReposQuery();
  const axios = useAxiosInterceptors();

  useEffect(() => {
    async function fetchExternalRepos() {
      const href = window.location.href;
      const url = href ? new URL(href) : undefined;
      const platform = url?.searchParams.get('platform');
      const login = url?.searchParams.get('login');
      console.log(platform, login);
      if (!platform || !login) return;

      const externalRepos = await getExternalRepos(axios, platform, login);
      const ids = externalRepos.map((repo) => repo.origin_id);
      await postExternalRepos(axios, platform, login, ids);
      await refetch();
    }
    fetchExternalRepos();
  }, []);

  return (
    <Card title="Repositories" extra={extra} loading={isLoading} bodyStyle={{ padding: 0 }}>
      {data && (
        <List<Repo>
          renderItem={(item) => {
            const { id, ...rest } = item;
            return id ? (
              <List.Item key={id}>
                <RepoListItem id={id} {...rest} />
              </List.Item>
            ) : undefined;
          }}
          dataSource={limit ? data.slice(0, limit) : data}
          size="large"
        />
      )}
    </Card>
  );
};
