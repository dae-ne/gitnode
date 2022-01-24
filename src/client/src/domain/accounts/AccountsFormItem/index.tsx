import React from 'react';
import { Form, Select } from 'antd';
import { userAccountsMock } from '../internal/_mock';

const { Option } = Select;

export interface AccountsFormItemProps {
  platform: string;
}

export const AccountsFormItem = ({ platform }: AccountsFormItemProps) => {
  const platformName = platform.toLowerCase();
  return (
    <Form.Item name="account" label="Account" rules={[{ required: true }]}>
      <Select placeholder="Select an account">
        {userAccountsMock
          .filter((account) => account.platform.toLowerCase() === platformName)
          .map((account) => {
            const { id, login } = account;
            return (
              <Option key={id} value={id}>
                {login}
              </Option>
            );
          })}
      </Select>
    </Form.Item>
  );
};
