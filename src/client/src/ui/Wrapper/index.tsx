import React from 'react';
import classNames from 'classnames';
import './styles.less';

export interface WrapperProps {
  background: 'transparent' | 'white';
  children: React.ReactNode;
}

const blockName = 'wrapper';

export const Wrapper = ({ background, children }: WrapperProps) => {
  return <div className={classNames(blockName, `${blockName}--${background}`)}>{children}</div>;
};
