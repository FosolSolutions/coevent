import { IPadlockState, IToken } from '.';

export interface IPadlockHook {
  state: IPadlockState;
  authenticated: boolean;
  login: (token: IToken) => void;
  logout: () => void;
}
