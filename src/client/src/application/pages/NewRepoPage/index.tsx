import React from 'react';
import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import { PageHeader, Page, PageTitleProp } from 'ui';

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

export const NewRepoPage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} header={renderHeader()}>
      asdf
    </Page>
  );
};
