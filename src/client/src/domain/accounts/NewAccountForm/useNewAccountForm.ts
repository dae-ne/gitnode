import { useEffect, useState } from 'react';
import { Form } from 'antd';
import { AccountsRepository } from 'infrastructure/codegen';
import { useNavigate } from 'react-router-dom';
import { useGitHubPopup, useGitLabPopup } from '../internal/hooks';

interface ValuesType {
  platform: string;
}

export const useNewAccountForm = () => {
  const [platform, setPlatform] = useState<string>();
  const navigate = useNavigate();
  const { code: gitHubCode, openPopup: openGitHubPopup } = useGitHubPopup();
  // const { code: bitbucketCode, openPopup: openBitbucketPopup } = useBitbucketPopup();
  const { code: gitLabCode, openPopup: openGitLabPopup } = useGitLabPopup();
  const [form] = Form.useForm();

  useEffect(() => {
    if (gitHubCode && platform) {
      const addAccount = async () => {
        const { login } = await AccountsRepository.addAccount({ code: gitHubCode, platform });
        navigate(`/?login=${login}&platform=${platform}`);
      };
      addAccount();
    }
  }, [gitHubCode]);

  const onFinish = (values: ValuesType) => {
    setPlatform(values.platform);
    openGitHubPopup();
  };

  return { form, onFinish };
};
