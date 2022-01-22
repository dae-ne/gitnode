import axiosInstance from 'axios';

export const axios = axiosInstance.create({
  baseURL: 'https://localhost:5001/api',
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
  },
});

export function get<T>(url: string): Promise<T> {
  return axios.get<T>(url).then((response) => response.data);
}

export function post<TReq, TRes>(url: string, body?: TReq): Promise<TRes> {
  return axios.post(url, body).then((response) => response.data);
}
