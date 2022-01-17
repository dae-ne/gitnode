import React from 'react';
import { Form, Input, Button, Radio } from 'antd';
import { PageHeader, Page, PageTitleProp, Container } from 'ui';

const renderHeader = () => {
  return <PageHeader title="Repository" back="show" />;
};

export const NewAccountPage = ({ title }: PageTitleProp) => {
  const [form] = Form.useForm();

  const onFinish = (values: unknown) => {
    console.log(values);
  };

  return (
    <Page className="repo-page" size="large" title={title} header={renderHeader()}>
      <div className="repo-page__content">
        <Container size="small">
          <p>
            Logout from platform that you want to add your account from to ensure, that you will add
            a correct one.
          </p>
          <Form layout="vertical" form={form} name="repository" onFinish={onFinish}>
            <Form.Item name="login" label="Login" rules={[{ required: true }]}>
              <Input />
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
            <Form.Item>
              <Button type="primary" htmlType="submit">
                Add
              </Button>
            </Form.Item>
          </Form>
        </Container>
      </div>
    </Page>
  );
};
