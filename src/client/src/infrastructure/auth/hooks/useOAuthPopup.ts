import { useEffect, useState } from 'react';

export const useOAuthPopup = (name: string, url: string, width = 500, height = 500) => {
  const [params, setParams] = useState('');
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

  useEffect(() => {
    const top = (screen.height - height) / 2;
    const left = (screen.width - width) / 2;
    setParams(
      `width=${width},height=${height},\
      left=${left},top=${top},\
      location=no,menubar=no,toolbar=no,status=no`,
    );
  }, [width, height]);

  const readAuthorizationCodeFromPopup = (
    win: Window,
    interval: ReturnType<typeof setInterval>,
  ) => {
    try {
      const href = win.location.href;
      const popupUrl = href ? new URL(href) : undefined;
      const parsedCode = popupUrl?.searchParams.get('code');

      if (parsedCode) {
        win.close();
        clearInterval(interval);
        setCode(parsedCode);
      }
    } catch {}
  };

  const openPopup = () => {
    if (!popup || popup.closed) {
      const win = window.open(url, name, params);
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
