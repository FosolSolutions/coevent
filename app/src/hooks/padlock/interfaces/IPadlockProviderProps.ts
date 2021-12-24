import { IToken, IUserInfo } from '.';

export interface IPadlockProviderProps extends React.HTMLAttributes<HTMLElement> {
  token?: IToken | null;
  authReady?: boolean;
  authenticated?: boolean;
  userInfo?: IUserInfo;
}
