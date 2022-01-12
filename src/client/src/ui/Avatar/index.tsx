import React from 'react';
import classNames from 'classnames';
import './styles.less';

export interface AvatarProps {
  size: 'small' | 'medium' | 'large';
  src: string;
}

export const Avatar = ({ size, src }: AvatarProps) => (
  <img className={classNames('avatar', `avatar--${size}`)} alt="" src={src} />
);
