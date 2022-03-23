import React from 'react';
import { LogoutOutlined } from '@ant-design/icons';
import { Dropdown, Menu } from 'antd';
import { Avatar } from 'ui';
import { useAvatarDropdown } from './useAvatarDropdown';
import './styles.less';

export interface AvatarDropdownProps {
  menu?: boolean;
}

export const AvatarDropdown = ({ menu }: AvatarDropdownProps) => {
  const { data, onMenuClick } = useAvatarDropdown(menu);

  if (!data) return <p>loading...</p>;

  const menuHeaderDropdown = (
    <Menu selectedKeys={[]} onClick={onMenuClick}>
      <Menu.Item key="logout">
        <div className="avatar-dropdown__menu-item">
          <LogoutOutlined />
          <p>sign out</p>
        </div>
      </Menu.Item>
    </Menu>
  );

  return (
    <Dropdown className="avatar-dropdown" overlay={menuHeaderDropdown}>
      <div className="avatar-dropdown__inner">
        <Avatar size="x-small" src={data.avatarUrl} />
        <span className="avatar-dropdown__login">{data.fullName}</span>
      </div>
    </Dropdown>
  );
};
