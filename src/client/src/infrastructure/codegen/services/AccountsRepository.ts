/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AccountResponseDto } from '../models/AccountResponseDto';
import type { AddAccountRequestDto } from '../models/AddAccountRequestDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { request as __request } from '../core/request';

export class AccountsRepository {

    /**
     * @param id 
     * @returns AccountResponseDto Success
     * @throws ApiError
     */
    public static getAccount(
id: number,
): CancelablePromise<AccountResponseDto> {
        return __request({
            method: 'GET',
            path: `/api/account/${id}`,
        });
    }

    /**
     * @param requestBody 
     * @returns AccountResponseDto Success
     * @throws ApiError
     */
    public static addAccount(
requestBody?: AddAccountRequestDto,
): CancelablePromise<AccountResponseDto> {
        return __request({
            method: 'POST',
            path: `/api/account`,
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @returns AccountResponseDto Success
     * @throws ApiError
     */
    public static getAccounts(): CancelablePromise<Array<AccountResponseDto>> {
        return __request({
            method: 'GET',
            path: `/api/accounts`,
        });
    }

}