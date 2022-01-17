import { useEffect, useState } from 'react';

const width = 500;
const height = 500;
const left = (screen.width - width) / 2;
const top = (screen.height - height) / 4;

const windowName = 'Sign in with Google';
const authUrl =
  'https://accounts.google.com/o/oauth2/v2/auth?' +
  'client_id=204500667909-ocghi7q393iacus7l8se2cm7dkkblc5e.apps.googleusercontent.com&' +
  'response_type=code&' +
  'scope=openid%20profile%20email&' +
  'redirect_uri=http%3A//localhost:3000&' +
  'access_type=offline&' +
  'prompt=consent';
const params = `width=${width},height=${height},\
  left=${left},top=${top},\
  location=no,menubar=no,toolbar=no,status=no`;

export const useGooglePopup = () => {
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
      const parsedCode = url?.searchParams.get('code');

      if (parsedCode) {
        win.close();
        clearInterval(interval);
        setCode(parsedCode);
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
