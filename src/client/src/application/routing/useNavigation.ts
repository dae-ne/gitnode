import { useEffect, useState } from 'react';
import { useLocation } from 'react-router';
import { PathNameType, ROUTER_PATHS } from '.';

export const useNavigation = () => {
  const { pathname } = useLocation();
  const [activeKey, setActiveKey] = useState<PathNameType | undefined>();

  useEffect(() => {
    const isValidKey = ROUTER_PATHS.map((link) => link as string).includes(pathname);
    const key = isValidKey ? pathname : undefined;
    // FIXME: remove ts-ignore and fix the problem
    // @ts-ignore
    setActiveKey(key);
  }, [pathname]);

  return { activeKey, setActiveKey };
};
