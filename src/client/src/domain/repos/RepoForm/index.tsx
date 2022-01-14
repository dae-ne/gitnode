import React from 'react';
import { Button, Form, Input, Switch } from 'antd';

export interface RepoFormProps {
  platforms: React.ReactNode;
  accounts: React.ReactNode;
  submitText: string;
}

export const RepoForm = ({ platforms, accounts, submitText }: RepoFormProps) => {
  const [form] = Form.useForm();

  const onFinish = (values: unknown) => {
    console.log(values);
  };

  return (
    <Form layout="vertical" form={form} name="repository" onFinish={onFinish}>
      <Form.Item name="name" label="Name" rules={[{ required: true }]}>
        <Input />
      </Form.Item>
      <Form.Item name="description" label="Description">
        <Input.TextArea />
      </Form.Item>
      {platforms}
      {accounts}
      <Form.Item name="private" label="Private" valuePropName="private">
        <Switch />
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType="submit">
          {submitText}
        </Button>
      </Form.Item>
    </Form>
  );
};
