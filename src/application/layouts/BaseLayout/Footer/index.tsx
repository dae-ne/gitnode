import React from 'react';
import { CopyrightOutlined } from '@ant-design/icons';
import { Layout } from 'antd';
import classNames from 'classnames';
import { Container } from 'ui';
import './styles.less';

const { Footer: LayoutFooter } = Layout;

export interface FooterProps {
  className?: string;
}

const links = [
  {
    key: 'PK',
    title: 'Cracow University of Technology',
    href: 'https://www.pk.edu.pl/index.php?lang=en',
    blankTarget: true,
  },
];

export const Footer = ({ className }: FooterProps) => {
  return (
    <Container size="x-large">
      <LayoutFooter className={classNames('footer', className)}>
        <div className="footer__links">
          {links.map((link) => (
            <a
              className="footer__link"
              key={link.key}
              title={link.key}
              target={link.blankTarget ? '_blank' : '_self'}
              href={link.href}
              rel="noreferrer"
            >
              {link.title}
            </a>
          ))}
        </div>
        <div className="footer__copyright">
          <p>
            <span>Copyright </span>
            <CopyrightOutlined />
            <span> {new Date().getFullYear()} Created by Rafał Czajka</span>
          </p>
        </div>
      </LayoutFooter>
    </Container>
  );
};
