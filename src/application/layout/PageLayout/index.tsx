import React from 'react';
import { Layout } from 'antd';
import { Outlet } from 'react-router';
import { Footer } from './Footer';
import { Header } from './Header';
import './styles.less';

const { Content } = Layout;

export const PageLayout = () => {
  return (
    <Layout className="page-layout">
      <Header className="page-layout__header" />
      <Content>
        <Outlet />
      </Content>
      <Footer className="page-layout__footer" />
    </Layout>
  );
};
