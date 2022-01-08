import React from 'react';
import { Menu, MenuProps } from 'antd';

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

export function NavMenu<TLinkKeys extends string>(props: NavMenuProps<TLinkKeys>) {
  const { defaultOpenKeys, openKeys, activeKey, defaultSelectedKeys, selectedKeys, ...otherProps } =
    props;
  return (
    <Menu
      theme="light"
      defaultOpenKeys={defaultOpenKeys}
      openKeys={openKeys}
      activeKey={activeKey}
      defaultSelectedKeys={defaultSelectedKeys}
      selectedKeys={selectedKeys}
      {...otherProps}
    />
  );
}
