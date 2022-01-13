import React from 'react';
import classNames from 'classnames';
import { Helmet } from 'react-helmet-async';
import { Container } from 'ui';
import './styles.less';

export interface PageTitleProp {
  title?: string;
}

export interface PageProps extends PageTitleProp {
  size?: 'medium' | 'large' | 'x-large';
  header?: React.ReactNode;
  children: React.ReactNode;
  className?: string;
}

const pageBaseTitle = '.gitnode';

export const Page = ({ size = 'x-large', header, children, title, className }: PageProps) => {
  return (
    <div className={classNames('page', className)}>
      <Helmet>
        <title>{title ? `${pageBaseTitle} | ${title}` : pageBaseTitle}</title>
      </Helmet>
      {header && (
        <header className="page__header">
          <Container size="ultra-large">{header}</Container>
        </header>
      )}
      <Container className="page__content" size={size}>
        {children}
      </Container>
    </div>
  );
};
