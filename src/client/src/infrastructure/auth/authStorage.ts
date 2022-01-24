import { readData, removeData, saveData } from 'infrastructure/storage';
import { AuthState } from '.';

const AUTH_KEY = 'auth';

export function saveTokens(auth: AuthState) {
  saveData(AUTH_KEY, auth);
}

export function getTokens(): AuthState | null {
  try {
    return readData(AUTH_KEY);
  } catch {
    return null;
  }
}

export function deleteTokens() {
  removeData(AUTH_KEY);
}
