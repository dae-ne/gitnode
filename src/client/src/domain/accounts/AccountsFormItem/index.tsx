import React from 'react';
import { Form, Select, Spin } from 'antd';
import { useAccountsFormItem } from './useAccountsFormItem';

const { Option } = Select;

export interface AccountsFormItemProps {
  platform?: string;
}

export const AccountsFormItem = ({ platform }: AccountsFormItemProps) => {
  const { isLoading, data } = useAccountsFormItem(platform);

  if (isLoading) return <Spin size="large" />;

  return (
    <Form.Item name="account" label="Account" rules={[{ required: true }]}>
      <Select placeholder="Select an account">
        {data.map((account) => {
          const { id, login } = account;
          return (
            <Option key={id} value={login}>
              {login}
            </Option>
          );
        })}
      </Select>
    </Form.Item>
  );
};
