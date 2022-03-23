import { NewAccountForm } from 'domain/accounts';
import { PlatformsFormItem } from 'domain/platforms';
import React from 'react';
import { PageHeader, Page, PageTitleProp, Container } from 'ui';
import './styles.less';

const renderHeader = () => {
  return <PageHeader title="Add a new account" back="show" />;
};

export const NewAccountPage = ({ title }: PageTitleProp) => {
  return (
    <Page className="new-account-page" size="large" title={title} header={renderHeader()}>
      <div className="new-account-page__inner">
        <Container size="small">
          <h1 className="new-account-page__header">Add your account</h1>
          <p className="new-account-page__text">
            Logout from platform that you want to add your account from to ensure, that you will add
            a correct one.
          </p>
          <NewAccountForm platforms={<PlatformsFormItem />} />
        </Container>
      </div>
    </Page>
  );
};
