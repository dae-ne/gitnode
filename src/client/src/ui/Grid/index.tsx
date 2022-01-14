import React from 'react';
import { Row as AntdRow, RowProps } from 'antd';
import classNames from 'classnames';
import { GridCol } from './GridCol';

export type GridProps = Omit<RowProps, 'gutter'>;

export interface GridType extends React.FC {
  Col: typeof GridCol;
}

export const Grid: GridType = ({ className, ...otherProps }: GridProps) => (
  <AntdRow className={classNames('grid', className)} gutter={24} {...otherProps} />
);

Grid.Col = GridCol;
