import { useRoutes } from 'react-router';
import { routes } from '.';

export const Router = () => {
  const routing = useRoutes(routes);
  return routing;
};
