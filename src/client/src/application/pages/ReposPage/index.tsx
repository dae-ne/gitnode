import { ReposListCard } from 'domain/repos';
import React from 'react';
import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import { Page, PageHeader, PageTitleProp } from 'ui';

const renderHeader = () => {
  const navigate = useNavigate();
  return (
    <PageHeader
      title="Repositories"
      extra={<Button onClick={() => navigate('/repos/new')}>Create repository</Button>}
    />
  );
};

export const ReposPage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} size="medium" header={renderHeader()}>
      <ReposListCard />
    </Page>
  );
};
