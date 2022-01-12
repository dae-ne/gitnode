import React from 'react';
import classNames from 'classnames';
import './styles.less';
import { Avatar } from 'ui';

export interface UserInfoProps {
  size: 'medium' | 'large';
  name: string;
  imageUrl: string;
  origin: string;
  className?: string;
}

export const UserInfo = ({ size, name, imageUrl, origin, className }: UserInfoProps) => {
  return (
    <div className={classNames('user-info', `user-info--${size}`, className)}>
      {imageUrl && <Avatar size={size} src={imageUrl} />}
      <p className="user-info__name">{name}</p>
      <p className="user-info__origin">{origin}</p>
    </div>
  );
};
