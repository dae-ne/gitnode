import { UpdateRepoForm } from 'domain/repos';
import React from 'react';
import { PageHeader, Page, PageTitleProp, Container, Wrapper } from 'ui';
import './styles.less';

const renderHeader = () => {
  return <PageHeader title="Repository" back="show" />;
};

export const RepoPage = ({ title }: PageTitleProp) => {
  return (
    <Page title={title} size="large" header={renderHeader()}>
      <Wrapper background="white">
        <Container size="small">
          <UpdateRepoForm submitText="Create" />
        </Container>
      </Wrapper>
    </Page>
  );
};
