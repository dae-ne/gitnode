import React from 'react';
import { Button, Descriptions } from 'antd';
import './styles.less';
import { Container, ContentHeader, PageWrapper } from 'ui';

export const HomePage = () => {
  return (
    <div className="home-page">
      <div className="home-page__header">
        <Container size="ultra-large">
          <ContentHeader
            title="Title"
            subTitle="This is a subtitle"
            extra={[
              <Button key="3">Operation</Button>,
              <Button key="2">Operation</Button>,
              <Button key="1" type="primary">
                Primary
              </Button>,
            ]}
          >
            <Descriptions size="small" column={3}>
              <Descriptions.Item label="Created">Lili Qu</Descriptions.Item>
              <Descriptions.Item label="Association">
                <a>421421</a>
              </Descriptions.Item>
              <Descriptions.Item label="Creation Time">2017-01-10</Descriptions.Item>
              <Descriptions.Item label="Effective Time">2017-10-10</Descriptions.Item>
              <Descriptions.Item label="Remarks">
                Gonghu Road, Xihu District, Hangzhou, Zhejiang, China
              </Descriptions.Item>
            </Descriptions>
          </ContentHeader>
        </Container>
      </div>
      <Container size="x-large">
        <PageWrapper>home page</PageWrapper>
      </Container>
    </div>
  );
};
