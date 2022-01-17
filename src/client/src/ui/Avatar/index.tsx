import React from 'react';
import classNames from 'classnames';
import './styles.less';

export interface AvatarProps {
  size: 'x-small' | 'small' | 'medium' | 'large';
  src: string;
  className?: string;
}

export const Avatar = ({ size, src, className }: AvatarProps) => (
  <img className={classNames('avatar', `avatar--${size}`, className)} alt="" src={src} />
);
