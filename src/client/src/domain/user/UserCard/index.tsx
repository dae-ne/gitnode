import React from 'react';
import { MailOutlined, CalendarOutlined } from '@ant-design/icons';
import { Divider } from 'antd';
import { Card, UserInfo } from 'ui';
import { useGetUserQuery } from '../internal/queries';
import './styles.less';

export const UserCard = () => {
  const { isLoading, data } = useGetUserQuery();

  const details = [
    {
      title: 'email',
      content: data?.email,
      icon: <MailOutlined />,
    },
    {
      title: 'created',
      content: data?.createdAt.toLocaleDateString(),
      icon: <CalendarOutlined />,
    },
  ];

  return (
    <Card className="user-card" title="User" loading={isLoading}>
      {data && (
        <>
          <UserInfo
            size="large"
            name={data.fullName}
            imageUrl={data.avatarUrl}
            origin="Google user"
          />
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
        </>
      )}
    </Card>
  );
};
