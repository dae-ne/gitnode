import React from 'react';
import { Button, Form } from 'antd';
import { useNewAccountForm } from './useNewAccountForm';

export interface NewAccountFormProps {
  platforms: React.ReactNode;
}

export const NewAccountForm = ({ platforms }: NewAccountFormProps) => {
  const { form, onFinish } = useNewAccountForm();

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
