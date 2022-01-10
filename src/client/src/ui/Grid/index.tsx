import React from 'react';
import { Col as AntdCol, Row as AntdRow, ColProps, RowProps } from 'antd';
import classNames from 'classnames';
import './styles.less';

export type GridColProps = ColProps;

export type GridRowProps = Omit<RowProps, 'gutter'>;

const Col = ({ className, ...otherProps }: GridColProps) => (
  <AntdCol className={classNames('grid--col', className)} {...otherProps} />
);

const Row = (props: GridRowProps) => <AntdRow gutter={24} {...props} />;

export interface GridType {
  Col: typeof Col;
  Row: typeof Row;
}

export const Grid: GridType = { Col, Row };
