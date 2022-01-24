/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { AddExternalReposRequestDto } from '../models/AddExternalReposRequestDto';
import type { AddRepoRequestDto } from '../models/AddRepoRequestDto';
import type { ExternalRepoResponseDto } from '../models/ExternalRepoResponseDto';
import type { RepoResponseDto } from '../models/RepoResponseDto';
import type { UpdateRepoRequestDto } from '../models/UpdateRepoRequestDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { request as __request } from '../core/request';

export class ReposRepository {

    /**
     * @param id 
     * @returns RepoResponseDto Success
     * @throws ApiError
     */
    public static getRepo(
id: number,
): CancelablePromise<RepoResponseDto> {
        return __request({
            method: 'GET',
            path: `/api/repo/${id}`,
        });
    }

    /**
     * @param id 
     * @param requestBody 
     * @returns any Success
     * @throws ApiError
     */
    public static updateRepo(
id: number,
requestBody?: UpdateRepoRequestDto,
): CancelablePromise<any> {
        return __request({
            method: 'PUT',
            path: `/api/repo/${id}`,
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param requestBody 
     * @returns RepoResponseDto Success
     * @throws ApiError
     */
    public static addRepo(
requestBody?: AddRepoRequestDto,
): CancelablePromise<RepoResponseDto> {
        return __request({
            method: 'POST',
            path: `/api/repo`,
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @returns RepoResponseDto Success
     * @throws ApiError
     */
    public static getRepos(): CancelablePromise<Array<RepoResponseDto>> {
        return __request({
            method: 'GET',
            path: `/api/repos`,
        });
    }

    /**
     * @param requestBody 
     * @returns any Success
     * @throws ApiError
     */
    public static addMultipleRepos(
requestBody?: AddExternalReposRequestDto,
): CancelablePromise<any> {
        return __request({
            method: 'POST',
            path: `/api/repos`,
            body: requestBody,
            mediaType: 'application/json',
        });
    }

    /**
     * @param platform 
     * @param account 
     * @returns ExternalRepoResponseDto Success
     * @throws ApiError
     */
    public static getExternalRepos(
platform: string,
account: string,
): CancelablePromise<Array<ExternalRepoResponseDto>> {
        return __request({
            method: 'GET',
            path: `/api/repos/${platform}/${account}`,
        });
    }

}