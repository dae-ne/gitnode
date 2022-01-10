import React from 'react';
import { PageHeader as AntdPageHeader, PageHeaderProps as AntdPageHeaderProps } from 'antd';
import classNames from 'classnames';
import './styles.less';

export interface PageHeaderProps extends Omit<AntdPageHeaderProps, 'onBack' | 'prefixCls'> {
  back?: 'show' | 'hide';
  children?: React.ReactNode;
}

export const PageHeader = ({
  back = 'hide',
  ghost = false,
  className,
  ...otherProps
}: PageHeaderProps) => {
  const goBack = () => {
    return window.history.back();
  };

  return (
    <AntdPageHeader
      className={classNames('page-header', className)}
      ghost={ghost}
      onBack={back === 'show' ? goBack : undefined}
      {...otherProps}
    />
  );
};
