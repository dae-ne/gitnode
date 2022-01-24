import { AxiosError, AxiosRequestConfig } from 'axios';
import { axiosConfig } from 'infrastructure/axios';

// import { ApiError } from './ApiError';
import type { ApiRequestOptions, Method } from './ApiRequestOptions';
import { CancelablePromise } from './CancelablePromise';
// import { CancelablePromise } from './CancelablePromise';
// import type { OnCancel } from './CancelablePromise';

// const isSuccess = (status: number) => {
//   return status >= 200 && status < 300;
// };

async function sendRequest<TReq, TRes>(
  url: string,
  method: Method,
  // onCancel: OnCancel,
  body?: TReq,
): Promise<TRes> {
  // const { token, cancel } = axios.CancelToken.source();

  const config: AxiosRequestConfig<TReq> = {
    url,
    method,
    data: body,
    // cancelToken: token,
  };

  // onCancel(() => cancel('The user aborted a request.'));

  try {
    return (await axiosConfig.request(config)).data;
  } catch (error) {
    const axiosError = error as AxiosError;
    if (axiosError.response) {
      return axiosError.response.data;
    }
    throw error;
  }
}

// function catchErrors(response: AxiosResponse): void {
//   if (!isSuccess(response.status)) {
//     throw new ApiError(response);
//   }
// }

export function request<TReq, TRes>(options: ApiRequestOptions<TReq>): CancelablePromise<TRes> {
  const { path, method, body } = options;
  return sendRequest<TReq, TRes>(path, method, body);
}

// export function request<TReq, TRes>(options: ApiRequestOptions<TReq>): CancelablePromise<TRes> {
//   return new CancelablePromise(async (resolve, reject, onCancel) => {
//     try {
//       const { path, method, body } = options;

//       if (!onCancel.isCancelled) {
//         const response = await sendRequest<TReq, TRes>(path, method, onCancel, body);
//         catchErrors(response);
//         resolve(response.data);
//       }
//     } catch (error) {
//       reject(error);
//     }
//   });
// }
