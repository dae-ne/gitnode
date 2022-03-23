import React, { useEffect } from 'react';
import { useNavigate } from 'react-router';
import { RepoForm, RepoFormProps } from '../internal/components';
import { useAddRepoQuery } from '../internal/queries';

export type AddRepoFormProps = Pick<RepoFormProps<null>, 'platforms' | 'accounts' | 'submitText'>;

export const AddRepoForm = (props: AddRepoFormProps) => {
  const { isLoading, mutate, status } = useAddRepoQuery();
  const navigate = useNavigate();

  useEffect(() => {
    status === 'success' && navigate('/');
  }, [status]);

  return <RepoForm isLoading={isLoading} onSubmit={mutate} {...props} />;
};
