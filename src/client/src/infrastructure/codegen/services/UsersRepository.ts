/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { UserResponseDto } from '../models/UserResponseDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { request as __request } from '../core/request';

export class UsersRepository {

    /**
     * @returns UserResponseDto Success
     * @throws ApiError
     */
    public static getAuthenticatedUser(): CancelablePromise<UserResponseDto> {
        return __request({
            method: 'GET',
            path: `/api/user`,
        });
    }

    /**
     * @returns any Success
     * @throws ApiError
     */
    public static removeUser(): CancelablePromise<any> {
        return __request({
            method: 'DELETE',
            path: `/api/user`,
        });
    }

    /**
     * @param id 
     * @returns UserResponseDto Success
     * @throws ApiError
     */
    public static getUser(
id: string,
): CancelablePromise<UserResponseDto> {
        return __request({
            method: 'GET',
            path: `/api/user/${id}`,
        });
    }

    /**
     * @returns UserResponseDto Success
     * @throws ApiError
     */
    public static getUsers(): CancelablePromise<Array<UserResponseDto>> {
        return __request({
            method: 'GET',
            path: `/api/users`,
        });
    }

}