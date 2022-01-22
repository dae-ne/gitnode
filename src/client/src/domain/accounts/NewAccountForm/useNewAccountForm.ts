import { useEffect, useState } from 'react';
import { Form } from 'antd';
import { useNavigate } from 'react-router-dom';
import { postAccount } from '../api';
import { useGitHubPopup } from '../hooks';

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
        const { login } = await postAccount(code, platform);
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
