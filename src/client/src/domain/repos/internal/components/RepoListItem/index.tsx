import React from 'react';
import { List } from 'antd';
import { Link } from 'react-router-dom';
import { Avatar } from 'ui';
import './styles.less';

const { Item } = List;
const { Meta } = Item;

export interface RepoListItemProps {
  id: number;
  name: string;
  description?: string;
  isPrivate: boolean;
  account: string;
}

export const RepoListItem = ({ id, name, description, isPrivate, account }: RepoListItemProps) => {
  return (
    <Item key={id} className="repo-list-item">
      <Meta
        title={
          <div className="repo-list-item__meta">
            <div className="repo-list-item__info">
              <Avatar
                className="repo-list-item__avatar"
                size="small"
                src="https://eu.ui-avatars.com/api/?name=Rafał+Czajka"
              />
              <p>
                {`${account} / `}
                <Link to={`/repos/${id}`}>{name}</Link>
              </p>
            </div>
            <div className="repo-list-item__accessibility">{isPrivate ? 'private' : 'public'}</div>
          </div>
        }
        description={<div className="repo-list-item__description">{description}</div>}
      />
    </Item>
  );
};
