export type Method = 'GET' | 'PUT' | 'POST' | 'DELETE' | 'OPTIONS' | 'HEAD' | 'PATCH';

export interface ApiRequestOptions<T> {
  readonly method: Method;
  readonly path: string;
  readonly body?: T;
  readonly mediaType?: string;
}
