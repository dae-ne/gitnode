import { useEffect, useState } from 'react';

const width = 500;
const height = 500;
const left = (screen.width - width) / 2;
const top = (screen.height - height) / 4;

const windowName = 'Sign in with Google';
const params = `width=${width},height=${height},\
  left=${left},top=${top},\
  location=no,menubar=no,toolbar=no,status=no`;

const createAuthUrl = () =>
  'https://github.com/login/oauth/authorize?' +
  'client_id=008d4433666f7d02672d&' +
  'redirect_uri=http%3A//localhost:3000/redirect&' +
  'scope=repo%20user&' +
  'allow_signup=true&';

export const useGitHubPopup = () => {
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
      const win = window.open(createAuthUrl(), windowName, params);
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
