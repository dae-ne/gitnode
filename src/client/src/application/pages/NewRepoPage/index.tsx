import { AccountsFormItem } from 'domain/accounts';
import { PlatformsFormItem } from 'domain/platforms';
import { AddRepoForm } from 'domain/repos';
import React, { useState } from 'react';
import { PageHeader, Page, PageTitleProp, Container, Wrapper } from 'ui';

const renderHeader = () => {
  return <PageHeader title="Create a new repository" back="show" />;
};

export const NewRepoPage = ({ title }: PageTitleProp) => {
  const [platform, setPlatform] = useState<string | undefined>();

  return (
    <Page title={title} size="large" header={renderHeader()}>
      <Wrapper background="white">
        <Container size="small">
          <AddRepoForm
            submitText="Create"
            platforms={<PlatformsFormItem onChange={setPlatform} />}
            accounts={<AccountsFormItem platform={platform} />}
          />
        </Container>
      </Wrapper>
    </Page>
  );
};
