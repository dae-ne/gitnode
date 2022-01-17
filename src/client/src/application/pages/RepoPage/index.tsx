import React from 'react';
import { Form, Input, Button, Select, Radio, Switch } from 'antd';
import { PageHeader, Page, PageTitleProp, Container } from 'ui';
import './styles.less';

const { Option } = Select;

const renderHeader = () => {
  return <PageHeader title="Repository" back="show" />;
};

export const RepoPage = ({ title }: PageTitleProp) => {
  const [form] = Form.useForm();

  const onFinish = (values: unknown) => {
    console.log(values);
  };

  return (
    <Page className="repo-page" size="large" title={title} header={renderHeader()}>
      <div className="repo-page__content">
        <Container size="small">
          <Form layout="vertical" form={form} name="repository" onFinish={onFinish}>
            <Form.Item name="name" label="Name" rules={[{ required: true }]}>
              <Input />
            </Form.Item>
            <Form.Item name="description" label="Description">
              <Input.TextArea />
            </Form.Item>
            <Form.Item
              name="platform"
              label="Platform"
              rules={[{ required: true, message: 'Please pick an item!' }]}
            >
              <Radio.Group>
                <Radio.Button value="github">GitHub</Radio.Button>
                <Radio.Button value="bitbucket">Bitbucket</Radio.Button>
                <Radio.Button value="gitlab">GitLab</Radio.Button>
              </Radio.Group>
            </Form.Item>
            <Form.Item name="account" label="Account" rules={[{ required: true }]}>
              <Select placeholder="Select an account">
                <Option value="male">male</Option>
                <Option value="female">female</Option>
                <Option value="other">other</Option>
              </Select>
            </Form.Item>
            <Form.Item name="private" label="Private" valuePropName="private">
              <Switch />
            </Form.Item>
            <Form.Item>
              <Button type="primary" htmlType="submit">
                Create
              </Button>
            </Form.Item>
          </Form>
        </Container>
      </div>
    </Page>
  );
};
