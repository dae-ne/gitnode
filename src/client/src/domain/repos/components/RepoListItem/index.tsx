import React from 'react';
import { List } from 'antd';

const { Item } = List;
const { Meta } = Item;

export interface RepoListItemProps {
  id: number;
  name: string;
  description?: string;
  url: string;
  isPrivate: boolean;
  account: string;
}

export const RepoListItem = ({
  id,
  name,
  description,
  url,
  isPrivate,
  account,
}: RepoListItemProps) => {
  return (
    <Item key={id}>
      <Meta
        title={
          <span>
            {account} / {name}
          </span>
        }
        description={description}
      />
    </Item>
  );
};
