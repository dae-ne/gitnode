import { useEffect, useState } from 'react';
import { Form } from 'antd';
import { authState, saveTokens, useGooglePopup } from 'infrastructure/auth';
import { AuthRepository } from 'infrastructure/codegen';
import { useNavigate } from 'react-router-dom';
import { useRecoilState } from 'recoil';

export interface LoginFormTypes {
  remember: boolean;
}

export const useLoginPage = () => {
  const navigate = useNavigate();
  const [remember, setRemember] = useState(false);
  const [auth, setAuth] = useRecoilState(authState);
  const { code, openPopup } = useGooglePopup();
  const [form] = Form.useForm();

  useEffect(() => {
    if (code) {
      const fetchTokens = async () => {
        const { id_token, refresh_token } = await AuthRepository.getToken({
          code,
          grant_type: 'authorization_code',
        });
        setAuth({ idToken: id_token, refreshToken: refresh_token });
      };
      fetchTokens();
    }
  }, [code]);

  useEffect(() => {
    const { idToken, refreshToken } = auth;

    if (idToken && refreshToken) {
      remember && saveTokens(auth);
      navigate('/');
    }
  }, [auth.idToken, auth.refreshToken]);

  const onFinish = (values: LoginFormTypes) => {
    setRemember(values.remember);
    openPopup();
  };

  return { form, onFinish };
};
