import React from 'react';
import { Layout } from 'antd';
import { Outlet } from 'react-router';
import { Footer } from './Footer';
import './styles.less';

export const BaseLayout = () => {
  return (
    <Layout className="base-layout">
      <Outlet />
      <Footer />
    </Layout>
  );
};
