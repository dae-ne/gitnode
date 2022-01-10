import React from 'react';
import { Button, Card, Descriptions } from 'antd';
import { Link } from 'react-router-dom';
import { PageHeader, Page, PageTitleProp, Grid } from 'ui';

const { Row, Col } = Grid;

const renderHeader = () => (
  <PageHeader
    title="Title"
    subTitle="This is a subtitle"
    extra={[
      <Button key="2">Operation</Button>,
      <Button key="1" type="primary">
        Primary
      </Button>,
    ]}
  >
    <Descriptions size="small" column={3}>
      <Descriptions.Item label="Created">Lili Qu</Descriptions.Item>
    </Descriptions>
  </PageHeader>
);

export const HomePage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} header={renderHeader()}>
      <Row>
        <Col xl={16} lg={24} md={24} sm={24} xs={24}>
          <Card title="Accounts" bordered={false}>
            <div>temporary content</div>
          </Card>
          <Card bordered={false} extra={<Link to="/repos">See all</Link>} title="Repositories">
            <div>temporary content</div>
          </Card>
        </Col>
        <Col xl={8} lg={24} md={24} sm={24} xs={24}>
          <Card title="Something" bordered={false}>
            <div>temporary content</div>
          </Card>
          <Card bordered={false} title="User">
            <div>temporary content</div>
          </Card>
          <Card bordered={false} title="Other">
            <div>temporary content</div>
          </Card>
        </Col>
      </Row>
    </Page>
  );
};
