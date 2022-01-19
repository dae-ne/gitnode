import React, { useEffect, useState } from 'react';
import { Button, Form } from 'antd';
import { useAxiosInterceptors } from 'infrastructure/api';
import { useNavigate } from 'react-router-dom';
import { postAccount } from '../api';
import { useGitHubPopup } from '../hooks';

export interface NewAccountFormProps {
  platforms: React.ReactNode;
}

interface ValuesType {
  platform: string;
}

export const NewAccountForm = ({ platforms }: NewAccountFormProps) => {
  const [platform, setPlatform] = useState<string>();
  const navigate = useNavigate();
  const axios = useAxiosInterceptors();
  const { code, openPopup } = useGitHubPopup();
  const [form] = Form.useForm();

  useEffect(() => {
    if (code && platform) {
      const addAccount = async () => {
        const { login } = await postAccount(axios, code, platform);
        navigate(`/?login=${login}&platform=${platform}`);
      };
      addAccount();
    }
  }, [code]);

  const onFinish = (values: ValuesType) => {
    setPlatform(values.platform);
    openPopup();
  };

  return (
    <Form layout="vertical" form={form} name="repository" onFinish={onFinish}>
      {platforms}
      <Form.Item>
        <Button type="primary" htmlType="submit">
          Add
        </Button>
      </Form.Item>
    </Form>
  );
};
