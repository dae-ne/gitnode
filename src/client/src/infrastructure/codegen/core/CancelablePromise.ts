/* eslint-disable @typescript-eslint/no-explicit-any */

// Token cancellation was removed from the project.
// The "openapi-typescript-codegen" needs that
// type to work properly, so it has to stay here.
// It'll be changed in the future.
export type CancelablePromise<T> = Promise<T>;
