export function saveData<T>(key: string, data: T) {
  localStorage.setItem(key, JSON.stringify(data));
}

export function readData<T>(key: string): T {
  const data = localStorage.getItem(key);

  if (!data) {
    throw new Error('Could not read data from local storage');
  }

  return JSON.parse(data);
}

export function removeData(key: string) {
  localStorage.removeItem(key);
}
