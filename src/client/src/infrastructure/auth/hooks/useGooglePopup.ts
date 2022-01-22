import { useOAuthPopup } from '.';

const windowName = 'Sign in with Google';
const authUrl =
  'https://accounts.google.com/o/oauth2/v2/auth?' +
  'client_id=204500667909-ocghi7q393iacus7l8se2cm7dkkblc5e.apps.googleusercontent.com&' +
  'response_type=code&' +
  'scope=openid%20profile%20email&' +
  'redirect_uri=http%3A//localhost:3000&' +
  'access_type=offline&' +
  'prompt=consent';

export const useGooglePopup = () => {
  return useOAuthPopup(windowName, authUrl);
};
