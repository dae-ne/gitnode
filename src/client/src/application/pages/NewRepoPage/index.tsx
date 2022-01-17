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
          <p>platform</p>
          <p>account</p>
          <RepoForm submitText="Create" />
        </Container>
      </Wrapper>
    </Page>
  );
};
