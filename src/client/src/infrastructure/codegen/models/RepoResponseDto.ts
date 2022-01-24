/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { RepoOwnerResponseDto } from './RepoOwnerResponseDto';

export type RepoResponseDto = {
    id: number;
    origin_id: number;
    name: string;
    description?: string;
    url: string;
    private: boolean;
    owner: RepoOwnerResponseDto;
}