import React from 'react';
import { Button, Form, Input, Spin, Switch } from 'antd';

export interface RepoFormProps<T> {
  isLoading: boolean;
  onSubmit: (data: T) => void;
  platforms?: React.ReactNode;
  accounts?: React.ReactNode;
  submitText: string;
  defaultName?: string;
  defaultDescription?: string;
  defaultPrivate?: boolean;
}

export function RepoForm<T>({
  isLoading,
  onSubmit,
  platforms,
  accounts,
  submitText,
  defaultName,
  defaultDescription,
  defaultPrivate,
}: RepoFormProps<T>) {
  const [form] = Form.useForm();

  if (isLoading) return <Spin size="large" />;

  return (
    <Form layout="vertical" form={form} name="repository" onFinish={onSubmit}>
      <Form.Item name="name" label="Name" rules={[{ required: true }]}>
        <Input defaultValue={defaultName} />
      </Form.Item>
      <Form.Item name="description" label="Description">
        <Input.TextArea defaultValue={defaultDescription} />
      </Form.Item>
      {platforms}
      {accounts}
      <Form.Item name="private" label="Private" valuePropName="true">
        <Switch defaultChecked={defaultPrivate} />
      </Form.Item>
      <Form.Item>
        <Button type="primary" htmlType="submit">
          {submitText}
        </Button>
      </Form.Item>
    </Form>
  );
}
