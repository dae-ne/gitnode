import { useCallback } from 'react';
import { authState, deleteTokens } from 'infrastructure/auth';
import { AuthRepository } from 'infrastructure/codegen';
import type { MenuInfo } from 'rc-menu/lib/interface';
import { useRecoilState } from 'recoil';
import { useGetUserQuery } from '../internal/queries';

export const useAvatarDropdown = (menu?: boolean) => {
  const [auth, setAuth] = useRecoilState(authState);
  const { data } = useGetUserQuery();
  const onMenuClick = useCallback(
    (event: MenuInfo) => {
      const { key } = event;
      if (key === 'logout') {
        AuthRepository.revokeToken({ token: auth.refreshToken });
        deleteTokens();
        setAuth({});
      }
    },
    [menu],
  );

  return { data, onMenuClick };
};
