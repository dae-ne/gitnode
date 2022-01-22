import React from 'react';
import { Button, Checkbox, Form, Layout } from 'antd';
import { useLoginPage } from './useLoginPage';
import './styles.less';

const { Content } = Layout;

export const LoginPage = () => {
  const { form, onFinish } = useLoginPage();

  return (
    <Content className="login-page">
      <div className="login-page__inner">
        <header className="login-page__header">
          <h1 className="login-page__logo">.gitnode</h1>
          <p className="login-page__text">Sed ac libero aliquet tortor placerat dignissim.</p>
        </header>
        <Form
          className="login-page__form"
          layout="vertical"
          form={form}
          name="repository"
          onFinish={onFinish}
        >
          <Form.Item name="remember" valuePropName="checked">
            <Checkbox>Remember me</Checkbox>
          </Form.Item>
          <Form.Item className="login-page__submit-item">
            <Button className="login-page__submit-button" htmlType="submit">
              Sign in with Google
            </Button>
          </Form.Item>
        </Form>
      </div>
    </Content>
  );
};
