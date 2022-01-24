import { useEffect, useState } from 'react';
import { Form } from 'antd';
import { AccountsRepository } from 'infrastructure/codegen';
import { useNavigate } from 'react-router-dom';
import { useGitHubPopup } from '../internal/hooks';

interface ValuesType {
  platform: string;
}

export const useNewAccountForm = () => {
  const [platform, setPlatform] = useState<string>();
  const navigate = useNavigate();
  const { code, openPopup } = useGitHubPopup();
  const [form] = Form.useForm();

  useEffect(() => {
    if (code && platform) {
      const addAccount = async () => {
        const { login } = await AccountsRepository.addAccount({ code, platform });
        navigate(`/?login=${login}&platform=${platform}`);
      };
      addAccount();
    }
  }, [code]);

  const onFinish = (values: ValuesType) => {
    setPlatform(values.platform);
    openPopup();
  };

  return { form, onFinish };
};
