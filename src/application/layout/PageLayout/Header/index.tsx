import React from 'react';
import { Layout, Menu } from 'antd';
import { PathNameType, useNavigation } from 'application/routing';
import classNames from 'classnames';
import { Link } from 'react-router-dom';
import { Container, NavMenu } from 'ui';
import './styles.less';

const { Header: LayoutHeader } = Layout;
const { Item } = Menu;

export interface HeaderProps {
  className?: string;
}

interface MenuLink {
  text: string;
  path: PathNameType;
}

const menuLinks: MenuLink[] = [
  {
    text: 'Home',
    path: '/',
  },
  {
    text: 'Repositories',
    path: '/repos',
  },
];

export const Header = ({ className }: HeaderProps) => {
  const { activeKey, setActiveKey } = useNavigation();
  return (
    <LayoutHeader className={classNames('header', className)}>
      <Container className="header__container" size="ultra-large">
        <div className="header__main">
          <div className="header__logo">
            <Link to="/">
              <h1>.ginode</h1>
            </Link>
          </div>
          <nav>
            <NavMenu<PathNameType>
              mode="horizontal"
              selectedKeys={activeKey ? [activeKey] : undefined}
            >
              {menuLinks.map((link) => (
                <Item className="header__nav-item" key={link.path}>
                  <Link to={link.path} onClick={() => setActiveKey(link.path)}>
                    {link.text}
                  </Link>
                </Item>
              ))}
            </NavMenu>
          </nav>
        </div>
        <h1 className="header__xd">Logo</h1>
      </Container>
    </LayoutHeader>
  );
};
