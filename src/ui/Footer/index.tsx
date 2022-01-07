import React from 'react';
import classNames from 'classnames';
import './index.less';

export interface FooterProps {
  links?: {
    key?: string;
    title: React.ReactNode;
    href: string;
    blankTarget?: boolean;
  }[];
  copyright?: React.ReactNode;
  style?: React.CSSProperties;
  className?: string;
}

export const Footer = ({ className, links, copyright, style }: FooterProps) => {
  if (
    (links == null || (Array.isArray(links) && links.length === 0)) &&
    (copyright == null || copyright === false)
  )
    return null;
  const clsString = classNames('footer', className);
  return (
    <footer className={clsString} style={style}>
      {links && (
        <div className="footer__links">
          {links.map((link) => (
            <a
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
      )}
      {copyright && <div className="footer__copyright">{copyright}</div>}
    </footer>
  );
};
