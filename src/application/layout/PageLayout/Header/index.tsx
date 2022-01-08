import React, { useState } from 'react';
import { Layout, Menu } from 'antd';
import classNames from 'classnames';
import { Link } from 'react-router-dom';
import './styles.less';

const { Header: LayoutHeader } = Layout;
const { Item } = Menu;

export interface HeaderProps {
  className?: string;
}

type LinkKeys = 'home' | 'repos' | 'accounts' | 'settings';

interface MenuLink {
  key: LinkKeys;
  text: string;
  to: string;
}

const menuLinks: MenuLink[] = [
  {
    key: 'home',
    text: 'Home',
    to: '/',
  },
  {
    key: 'repos',
    text: 'Repositories',
    to: '/repos',
  },
  {
    key: 'accounts',
    text: 'Accounts',
    to: '/',
  },
  {
    key: 'settings',
    text: 'Settings',
    to: '/',
  },
];

export const Header = ({ className }: HeaderProps) => {
  const [activeKey, setActiveKey] = useState<LinkKeys>('home');
  return (
    <LayoutHeader className={classNames('header', className)}>
      <div className="header__main">
        <div className="header__logo">
          <Link to="/">
            <h1>.ginode</h1>
          </Link>
        </div>
        <nav>
          <Menu theme="light" mode="horizontal" selectedKeys={[activeKey]}>
            {menuLinks.map((link) => (
              <Item className="header__nav-item" key={link.key}>
                <Link key={`link-${link.key}`} to={link.to} onClick={() => setActiveKey(link.key)}>
                  {link.text}
                </Link>
              </Item>
            ))}
          </Menu>
        </nav>
      </div>
      <h1 className="header__xd">Logo</h1>
    </LayoutHeader>
  );
};
