export interface IResponseError {
  type: string;
  title: string;
  status: number;
  traceId?: string;
  errors: IValidationError[];
}

export interface IValidationError {
  model: string[];
  [index: string]: string[];
}
