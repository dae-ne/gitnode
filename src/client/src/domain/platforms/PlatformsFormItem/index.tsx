import React from 'react';
import { Form, Radio, RadioChangeEvent } from 'antd';
import { platformsMock } from '../_mock';

export interface PlatformsFormItem {
  onChange: (name: string) => void;
}

export const PlatformsFormItem = ({ onChange }: PlatformsFormItem) => {
  const handleValueChange = (event: RadioChangeEvent) => onChange(event.target.value);
  return (
    <Form.Item
      name="platform"
      label="Platform"
      rules={[{ required: true, message: 'Please pick an item!' }]}
    >
      <Radio.Group onChange={handleValueChange}>
        {platformsMock.map((platform) => {
          const { id, name } = platform;
          return (
            <Radio.Button key={id} value={name.toLowerCase()}>
              {name}
            </Radio.Button>
          );
        })}
      </Radio.Group>
    </Form.Item>
  );
};
