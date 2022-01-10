import { AccountsListCard } from 'domain/accounts';
import { ReposListCard } from 'domain/repos';
import { UserCard } from 'domain/user';
import React from 'react';
import { Button } from 'antd';
import { Link } from 'react-router-dom';
import { PageHeader, Page, PageTitleProp, Grid, Card } from 'ui';

const { Col } = Grid;

const renderHeader = () => (
  <PageHeader
    title="Home"
    extra={[<Button key="1">Add account</Button>, <Button key="2">Create repository</Button>]}
  />
);

export const HomePage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} header={renderHeader()}>
      <Grid>
        <Col xl={16} lg={24} md={24} sm={24} xs={24}>
          <AccountsListCard />
          <ReposListCard limit={6} extra={<Link to="/repos">See all</Link>} />
        </Col>
        <Col xl={8} lg={24} md={24} sm={24} xs={24}>
          <UserCard />
          <Card></Card>
        </Col>
      </Grid>
    </Page>
  );
};
