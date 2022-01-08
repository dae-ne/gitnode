import React from 'react';

import { Layout } from 'antd';
import { Footer } from 'application/layout/PageLayout/Footer';
import { Header } from 'application/layout/PageLayout/Header';
import { Outlet } from 'react-router';
import './styles.less';

const { Content } = Layout;

export const PageLayout = () => {
  return (
    <Layout className="page-layout">
      <Header className="page-layout__header" />
      <Content className="page-layout__content">
        <Outlet />
      </Content>
      <Footer className="page-layout__footer" />
    </Layout>
  );
};
