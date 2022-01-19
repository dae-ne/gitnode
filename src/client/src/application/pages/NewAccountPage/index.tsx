import { NewAccountForm } from 'domain/accounts';
import { PlatformsFormItem } from 'domain/platforms';
import React from 'react';
import { PageHeader, Page, PageTitleProp, Container } from 'ui';

const renderHeader = () => {
  return <PageHeader title="Repository" back="show" />;
};

export const NewAccountPage = ({ title }: PageTitleProp) => {
  return (
    <Page className="repo-page" size="large" title={title} header={renderHeader()}>
      <div className="repo-page__content">
        <Container size="small">
          <p>
            Logout from platform that you want to add your account from to ensure, that you will add
            a correct one.
          </p>
          <NewAccountForm platforms={<PlatformsFormItem />} />
        </Container>
      </div>
    </Page>
  );
};
