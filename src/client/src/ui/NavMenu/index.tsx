import React from 'react';
import { Menu, MenuProps } from 'antd';
import './styles.less';

type OmmitedProps =
  | 'theme'
  | 'prefixCls'
  | 'defaultOpenKeys'
  | 'openKeys'
  | 'activeKey'
  | 'defaultSelectedKeys'
  | 'selectedKeys';

export interface NavMenuProps<TLinkKeys extends string> extends Omit<MenuProps, OmmitedProps> {
  defaultOpenKeys?: TLinkKeys[];
  openKeys?: TLinkKeys[];
  activeKey?: TLinkKeys;
  defaultSelectedKeys?: TLinkKeys[];
  selectedKeys?: TLinkKeys[];
}

export function NavMenu<TLinkKeys extends string>({
  defaultOpenKeys,
  openKeys,
  activeKey,
  defaultSelectedKeys,
  selectedKeys,
  ...otherProps
}: NavMenuProps<TLinkKeys>) {
  return (
    <Menu
      className="nav-menu"
      theme="dark"
      defaultOpenKeys={defaultOpenKeys}
      openKeys={openKeys}
      activeKey={activeKey}
      defaultSelectedKeys={defaultSelectedKeys}
      selectedKeys={selectedKeys}
      {...otherProps}
    />
  );
}
