/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { GetTokenRequestDto } from '../models/GetTokenRequestDto';
import type { RevokeTokenRequestDto } from '../models/RevokeTokenRequestDto';
import type { TokenResponseDto } from '../models/TokenResponseDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { request as __request } from '../core/request';

export class AuthRepository {

    /**
     * @param requestBody 
     * @returns TokenResponseDto Success
     * @throws ApiError
     */
    public static getToken(
requestBody?: GetTokenRequestDto,
): CancelablePromise<TokenResponseDto> {
        return __request({
            method: 'POST',
            path: `/api/auth/token`,
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody 
     * @returns any Success
     * @throws ApiError
     */
    public static revokeToken(
requestBody?: RevokeTokenRequestDto,
): CancelablePromise<any> {
        return __request({
            method: 'POST',
            path: `/api/auth/revoke`,
            body: requestBody,
            mediaType: 'application/json',
        });
    }

}