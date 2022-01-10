import React from 'react';
import classNames from 'classnames';
import { Helmet } from 'react-helmet-async';
import { Container } from 'ui';
import './styles.less';

export interface PageTitleProp {
  title: string;
}

export interface PageProps extends PageTitleProp {
  header?: React.ReactNode;
  children: React.ReactNode;
  className?: string;
}

export const Page = ({ header, children, title, className }: PageProps) => {
  return (
    <div className={classNames('page-content', className)}>
      <Helmet>
        <title>.gitnode | {title}</title>
      </Helmet>
      {header && (
        <header className="page-content__header">
          <Container size="ultra-large">{header}</Container>
        </header>
      )}
      <Container className="page-content__content" size="x-large">
        {children}
      </Container>
    </div>
  );
};
