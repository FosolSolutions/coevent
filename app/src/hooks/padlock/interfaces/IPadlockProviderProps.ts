import React from 'react';

import { IOIDCEndpoints, IToken, IUserInfo } from '.';

export interface IPadlockProviderProps extends React.HTMLAttributes<HTMLElement> {
  oidc?: IOIDCEndpoints;
  token?: IToken | null;
  authReady?: boolean;
  authenticated?: boolean;
  userInfo?: IUserInfo;
}
