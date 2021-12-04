import { IToken, IUserInfo } from '.';

export interface IAccountState {
  authReady: boolean;
  setAuthReady: React.Dispatch<React.SetStateAction<boolean>>;
  authenticated: boolean;
  setAuthenticated: React.Dispatch<React.SetStateAction<boolean>>;
  token?: IToken | null;
  setToken: React.Dispatch<React.SetStateAction<IToken | null | undefined>>;
  userInfo?: IUserInfo;
  setUserInfo: React.Dispatch<React.SetStateAction<IUserInfo | undefined>>;
}
