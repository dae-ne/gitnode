import { atom, selector } from 'recoil';
import { getTokens } from './authStorage';

export interface AuthState {
  idToken?: string;
  refreshToken?: string;
}

export const authState = atom({
  key: 'auth',
  default: getTokens() ?? ({} as AuthState),
});

export const isAuthenticatedState = selector({
  key: 'isAuthenticated',
  get: ({ get }) => {
    const { idToken, refreshToken } = get(authState);
    return !!idToken && !!refreshToken;
  },
});
