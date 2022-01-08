import React from 'react';
import classNames from 'classnames';
import './styles.less';

export interface ContainerProps {
  size: 'small' | 'medium' | 'large' | 'x-large' | 'xx-large' | 'fluid';
  children?: React.ReactNode;
  className?: string;
}

export const Container = ({ size, children, className }: ContainerProps) => {
  return <div className={classNames('container', `container--${size}`, className)}>{children}</div>;
};
