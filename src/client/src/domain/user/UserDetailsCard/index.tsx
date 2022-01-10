import React from 'react';
import { MailOutlined, CalendarOutlined } from '@ant-design/icons';
import { Divider } from 'antd';
import classNames from 'classnames';
import { Card, CardProps } from 'ui';
import { authenticatedUserMock } from '../_mock';
import './styles.less';

export type UserDetailsCardProps = Omit<CardProps, 'title'>;

export const UserDetailsCard = ({ className, ...cardProps }: UserDetailsCardProps) => {
  const { givenName, surname, email, createdAt, imageUrl } = authenticatedUserMock;

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
    <Card className={classNames('user-details-card', className)} title="User" {...cardProps}>
      <div className="user-details-card__info">
        {imageUrl && <img className="user-details-card__avatar" alt="" src={imageUrl} />}
        <p className="user-details-card__name">
          {givenName} {surname}
        </p>
        <p className="user-details-card__origin">Google user</p>
      </div>
      <Divider dashed />
      <ul className="user-details-card__details">
        {details.map((item) => (
          <li key={item.title} className="user-details-card__detail-item">
            <p>
              {item.icon}
              <span className="user-details-card__detail-title">{item.title}: </span>
              <span className="user-details-card__detail-content">{item.content}</span>
            </p>
          </li>
        ))}
      </ul>
    </Card>
  );
};
