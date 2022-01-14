import React from 'react';
import { Col, ColProps } from 'antd';
import classNames from 'classnames';
import './styles.less';

export type GridColProps = ColProps;

export const GridCol = ({ className, ...otherProps }: ColProps) => (
  <Col className={classNames('grid-col', className)} {...otherProps} />
);
