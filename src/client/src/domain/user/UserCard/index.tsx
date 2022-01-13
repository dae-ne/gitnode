import React from 'react';
import { MailOutlined, CalendarOutlined } from '@ant-design/icons';
import { Divider } from 'antd';
import { Card, UserInfo } from 'ui';
import { authenticatedUserMock } from '../_mock';
import './styles.less';

export const UserCard = () => {
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
    <Card className="user-card" title="User">
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
