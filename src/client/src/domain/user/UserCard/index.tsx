import React from 'react';
import { MailOutlined, CalendarOutlined } from '@ant-design/icons';
import { Divider } from 'antd';
import classNames from 'classnames';
import { Card, CardProps, UserInfo } from 'ui';
import { authenticatedUserMock } from '../_mock';
import './styles.less';

export type UserCardProps = Omit<CardProps, 'title'>;

export const UserCard = ({ className, ...cardProps }: UserCardProps) => {
  const { givenName, surname, email, createdAt, avatarUrl: imageUrl } = authenticatedUserMock;
  const fullName = `${givenName} ${surname}`;

  const details = [
    {
      title: 'email',
      content: email,
      icon: <MailOutlined />,
    },
    {
      title: 'created',
      content: createdAt.toLocaleDateString(),
      icon: <CalendarOutlined />,
    },
  ];

  return (
    <Card className={classNames('user-card', className)} title="User" {...cardProps}>
      <UserInfo size="large" name={fullName} imageUrl={imageUrl} origin="Google user" />
      <Divider dashed />
      <ul className="user-card__details">
        {details.map((item) => (
          <li key={item.title} className="user-card__detail-item">
            <p>
              {item.icon}
              <span className="user-card__detail-title">{item.title}: </span>
              <span className="user-card__detail-content">{item.content}</span>
            </p>
          </li>
        ))}
      </ul>
    </Card>
  );
};
