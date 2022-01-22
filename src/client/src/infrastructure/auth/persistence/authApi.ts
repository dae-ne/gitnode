import { post } from 'infrastructure/persistence/axios';

export interface TokenResponseDto {
  id_token: string;
  refresh_token?: string;
  expires_in: number;
  scope: string;
  token_type: string;
}

// TODO: request dtos

export const authenticate = (code: string) => {
  const body = { code, grant_type: 'authorization_code' };
  return post<typeof body, TokenResponseDto>('/auth/token', body);
};

export const refreshToken = (token: string) => {
  const body = { refresh_token: token, grant_type: 'refresh_token' };
  return post<typeof body, TokenResponseDto>('/auth/token', body);
};

export const revokeToken = (token: string) => {
  const body = { token };
  return post<typeof body, TokenResponseDto>('/auth/revoke', body);
};
