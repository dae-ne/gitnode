import { AccountsListCard } from 'domain/accounts';
import React from 'react';
import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import { Page, PageHeader, PageTitleProp } from 'ui';

const renderHeader = () => {
  const navigate = useNavigate();
  return (
    <PageHeader
      title="Accounts"
      extra={<Button onClick={() => navigate('/accounts/new')}>Add account</Button>}
    />
  );
};

export const AccountsPage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} size="large" header={renderHeader()}>
      <AccountsListCard showHeader={false} />
    </Page>
  );
};
