import { isAuthenticatedState } from 'infrastructure/auth';
import { useRoutes } from 'react-router';
import { useRecoilValue } from 'recoil';
import { routes } from '.';

export const Router = () => {
  const authenticated = useRecoilValue(isAuthenticatedState);
  const routing = useRoutes(routes(authenticated));
  return routing;
};
