import React from 'react';
import { Card as AntdCard, CardProps as AntdCardProps } from 'antd';

export type CardProps = AntdCardProps;

export const Card = ({ bordered = false, ...otherProps }: CardProps) => {
  return <AntdCard bordered={bordered} {...otherProps} />;
};
