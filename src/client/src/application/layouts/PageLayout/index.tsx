import React from 'react';
import { Layout } from 'antd';
import { Outlet } from 'react-router';
import { Header } from './Header';

const { Content } = Layout;

export const PageLayout = () => {
  return (
    <>
      <Header />
      <Content>
        <Outlet />
      </Content>
    </>
  );
};
