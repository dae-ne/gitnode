import React from 'react';
import { PageHeader as AntdPageHeader, PageHeaderProps as AntdPageHeaderProps } from 'antd';
import classNames from 'classnames';
import './styles.less';

export interface PageHeaderProps extends Omit<AntdPageHeaderProps, 'onBack' | 'prefixCls'> {
  back?: 'show' | 'hide';
  children?: React.ReactNode;
}

export const ContentHeader = (props: PageHeaderProps) => {
  const { back = 'show', ghost = false, className, ...otherProps } = props;

  const goBack = () => {
    return back === 'show' ? window.history.back() : undefined;
  };

  return (
    <AntdPageHeader
      className={classNames('content-header', className)}
      ghost={ghost}
      onBack={goBack}
      {...otherProps}
    />
  );
};
