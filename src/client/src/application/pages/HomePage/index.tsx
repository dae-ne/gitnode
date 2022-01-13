import { AccountsListCard } from 'domain/accounts';
import { ReposListCard } from 'domain/repos';
import { UserCard } from 'domain/user';
import React from 'react';
import { Button } from 'antd';
import { Link, useNavigate } from 'react-router-dom';
import { PageHeader, Page, PageTitleProp, Grid } from 'ui';

const { Col } = Grid;

const renderHeader = () => {
  const navigate = useNavigate();
  return (
    <PageHeader
      title="Home"
      extra={[
        <Button key="1" onClick={() => navigate('/accounts/new')}>
          Add account
        </Button>,
        <Button key="2" onClick={() => navigate('/repos/new')}>
          Create repository
        </Button>,
      ]}
    />
  );
};

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
        </Col>
      </Grid>
    </Page>
  );
};
