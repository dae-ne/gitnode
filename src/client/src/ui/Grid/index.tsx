import React from 'react';
import { Col as AntdCol, Row as AntdRow, ColProps, RowProps } from 'antd';
import classNames from 'classnames';
import './styles.less';

export type GridProps = Omit<RowProps, 'gutter'>;

export type GridColProps = ColProps;

export class Grid extends React.Component<GridProps> {
  static Col({ className, ...otherProps }: GridColProps) {
    return <AntdCol className={classNames('grid__col', className)} {...otherProps} />;
  }

  render() {
    const { className, ...otherProps } = this.props;
    return <AntdRow className={classNames('grid', className)} gutter={24} {...otherProps} />;
  }
}
