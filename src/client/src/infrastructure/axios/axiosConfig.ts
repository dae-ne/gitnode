import axiosInstance from 'axios';

export const axiosConfig = axiosInstance.create({
  baseURL: 'http://localhost:5000',
  headers: {
    'Content-Type': 'application/json',
    Accept: 'application/json',
  },
});
