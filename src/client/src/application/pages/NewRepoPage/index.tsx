import { AccountsFormItem } from 'domain/accounts/AccountsFormItem';
import { PlatformsFormItem } from 'domain/platforms';
import { RepoForm } from 'domain/repos';
import React from 'react';
import { PageHeader, Page, PageTitleProp, Container, Wrapper } from 'ui';

const renderHeader = () => {
  return <PageHeader title="Create a new repository" back="show" />;
};

export const NewRepoPage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} size="large" header={renderHeader()}>
      <Wrapper background="white">
        <Container size="small">
          <RepoForm
            platforms={<PlatformsFormItem onChange={(text: string) => console.log(text)} />}
            accounts={<AccountsFormItem platform="GitHub" />}
            submitText="Create"
          />
        </Container>
      </Wrapper>
    </Page>
  );
};
