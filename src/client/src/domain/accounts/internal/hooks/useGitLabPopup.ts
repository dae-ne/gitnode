import { useEffect, useState } from 'react';

const width = 500;
const height = 500;
const left = (screen.width - width) / 2;
const top = (screen.height - height) / 4;

const windowName = 'Sign in with GitLab';
const params = `width=${width},height=${height},\
  left=${left},top=${top},\
  location=no,menubar=no,toolbar=no,status=no`;

const authUrl =
  'https://gitlab.com/oauth/authorize?' +
  'client_id=51ac13816c0fecaa2938f1b239e7d49d463df7f0e5246c8bb297a61d87ada113&' +
  'redirect_uri=http%3A//localhost:3000&' +
  'response_type=code&' +
  'scope=api';

export const useGitLabPopup = () => {
  const [code, setCode] = useState<string | undefined>(undefined);
  const [popup, setPopup] = useState<Window | null>(null);
  const [intervals, setIntervals] = useState<ReturnType<typeof setInterval>[]>([]);

  useEffect(() => {
    return () => {
      intervals.forEach((interval) => {
        clearInterval(interval);
      });
    };
  }, []);

  const readAuthorizationCodeFromPopup = (
    win: Window,
    interval: ReturnType<typeof setInterval>,
  ) => {
    try {
      const href = win.location.href;
      const url = href ? new URL(href) : undefined;
      const fetchedCode = url?.searchParams.get('code');

      if (fetchedCode) {
        win.close();
        clearInterval(interval);
        setCode(fetchedCode);
      }
    } catch {}
  };

  const openPopup = () => {
    if (!popup || popup.closed) {
      const win = window.open(authUrl, windowName, params);
      setPopup(win);
      const interval: ReturnType<typeof setInterval> = setInterval(
        () => win && readAuthorizationCodeFromPopup(win, interval),
        100,
      );
      setIntervals((prev) => [...prev, interval]);
    } else popup.focus();
  };

  return {
    code,
    openPopup,
  };
};
