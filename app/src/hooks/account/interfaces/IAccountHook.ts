import { IAccountState } from '.';

export interface IAccountHook {
  state: IAccountState;
  authenticated: boolean;
}
