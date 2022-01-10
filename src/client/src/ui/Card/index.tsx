import React from 'react';
import { Card as AntdCard, CardProps as AntdCardProps } from 'antd';
import {
  CardGridProps as AntdCardGridProps,
  CardMetaProps as AntdCardMetaProps,
} from 'antd/lib/card';

const { Meta: AntdCardMeta, Grid: AntdCardGrid } = AntdCard;

export type CardProps = AntdCardProps;

export type CardMetaProps = AntdCardMetaProps;

export type CardGridProps = AntdCardGridProps;

export class Card extends React.Component<CardProps> {
  static Meta(props: CardMetaProps) {
    return <AntdCardMeta {...props} />;
  }

  static Grid(props: CardGridProps) {
    return <AntdCardGrid {...props} />;
  }

  render() {
    const { bordered = false, ...otherProps } = this.props;
    return <AntdCard bordered={bordered} {...otherProps} />;
  }
}
