import { IAccountState, IToken } from '.';

export interface IAccountHook {
  state: IAccountState;
  authenticated: boolean;
  login: (token: IToken) => void;
  logout: () => void;
}
