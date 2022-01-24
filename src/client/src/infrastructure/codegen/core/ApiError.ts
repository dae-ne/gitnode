import { AxiosResponse } from 'axios';

export class ApiError<T> extends Error {
  public readonly url?: string;
  public readonly status: number;
  public readonly statusText: string;
  public readonly body: T;

  constructor(response: AxiosResponse<T>) {
    super(response.statusText);

    this.name = 'ApiError';
    this.url = response.config.url;
    this.status = response.status;
    this.statusText = response.statusText;
    this.body = response.data;
  }
}
