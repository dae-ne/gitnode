import React, { useEffect } from 'react';
import { Button, Checkbox, Form, Layout } from 'antd';
import { authenticate, authState, useGooglePopup } from 'infrastructure/auth';
import { useNavigate } from 'react-router-dom';
import { useRecoilState } from 'recoil';
import './styles.less';

const { Content } = Layout;

export const LoginPage = () => {
  const navigate = useNavigate();
  const [auth, setAuth] = useRecoilState(authState);
  const { code, openPopup } = useGooglePopup();
  const [form] = Form.useForm();

  useEffect(() => {
    if (code) {
      const fetchTokens = async () => {
        const response = await authenticate(code);
        const { id_token, refresh_token } = response.data;
        setAuth({ idToken: id_token, refreshToken: refresh_token });
      };
      fetchTokens();
    }
  }, [code]);

  useEffect(() => {
    const { idToken, refreshToken } = auth;
    idToken && refreshToken && navigate('/');
  }, [auth.idToken, auth.refreshToken]);

  const onFinish = (values: unknown) => {
    console.log(code);
    console.log(values);
    openPopup();
  };

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
