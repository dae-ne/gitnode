import { AccountCard } from 'domain/accounts';
import { ReposListCard } from 'domain/repos';
import React, { useMemo } from 'react';
import { useParams } from 'react-router-dom';
import { PageHeader, Page, PageTitleProp, Grid } from 'ui';

const { Col } = Grid;

const renderHeader = () => <PageHeader title="Account" back="show" />;

export const AccountPage = ({ title }: PageTitleProp) => {
  const { accountId } = useParams();
  const id = useMemo(() => (accountId ? parseInt(accountId) : undefined), [accountId]);

  if (!accountId || !id) {
    return <></>;
  }

  return (
    <Page title={title} header={renderHeader()}>
      <Grid>
        <Col xl={8} lg={24} md={24} sm={24} xs={24}>
          <AccountCard accountId={id} />
        </Col>
        <Col xl={16} lg={24} md={24} sm={24} xs={24}>
          <ReposListCard accountId={id} />
        </Col>
      </Grid>
    </Page>
  );
};
