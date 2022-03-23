import React from 'react';
import { RepoForm, RepoFormProps } from '../internal/components';
import { useUpdateRepoForm } from './useUpdateRepoForm';

export type UpdateRepoFormProps = Pick<RepoFormProps<null>, 'submitText'>;

export const UpdateRepoForm = (props: UpdateRepoFormProps) => {
  const { isLoading, data, onSubmit } = useUpdateRepoForm();

  return (
    <RepoForm
      isLoading={isLoading}
      onSubmit={onSubmit}
      defaultName={data?.name}
      defaultDescription={data?.description}
      defaultPrivate={data?.isPrivate}
      {...props}
    />
  );
};
