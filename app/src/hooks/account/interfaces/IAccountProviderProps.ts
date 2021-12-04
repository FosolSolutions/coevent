import { IToken, IUserInfo } from '.';

export interface IAccountProviderProps extends React.HTMLAttributes<HTMLElement> {
  token?: IToken | null;
  authReady?: boolean;
  authenticated?: boolean;
  userInfo?: IUserInfo;
}
