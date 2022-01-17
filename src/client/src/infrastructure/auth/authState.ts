import { atom, selector } from 'recoil';

export interface AuthState {
  idToken?: string;
  refreshToken?: string;
}

export const authState = atom({
  key: 'auth',
  default: {} as AuthState,
});

export const isAuthenticatedState = selector({
  key: 'isAuthenticated',
  get: ({ get }) => {
    const { idToken, refreshToken } = get(authState);
    return !!idToken && !!refreshToken;
  },
});
