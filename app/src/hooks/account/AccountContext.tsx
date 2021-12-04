import React from 'react';

import { IAccountProviderProps, IAccountState, IToken, IUserInfo } from './interfaces';

/**
 * AccountContext, provides shared state between AJAX requests.
 */
export const AccountContext = React.createContext<IAccountState>({
  authReady: false,
  setAuthReady: () => {},
  authenticated: false,
  setAuthenticated: () => {},
  setToken: () => {},
  setUserInfo: () => {},
});

/**
 * AccountProvider, provides a way to initialize context.
 * @param param0 AccountProvider initialization properties.
 * @returns
 */
export const AccountProvider: React.FC<IAccountProviderProps> = ({
  authReady: initAuthReady = false,
  authenticated: initAuthenticated = false,
  token: initToken,
  userInfo: initUserInfo,
  children,
}) => {
  const [authReady, setAuthReady] = React.useState<boolean>(initAuthReady);
  const [token, setToken] = React.useState<IToken | null | undefined>(initToken);
  const [authenticated, setAuthenticated] = React.useState<boolean>(initAuthenticated);
  const [userInfo, setUserInfo] = React.useState<IUserInfo | undefined>(initUserInfo);

  React.useEffect(() => {
    // Configure account authentication solution.
    setAuthReady(true);
  }, [setAuthReady]);

  return (
    <AccountContext.Provider
      value={{
        authReady,
        setAuthReady,
        authenticated,
        setAuthenticated,
        token,
        setToken,
        userInfo,
        setUserInfo,
      }}
    >
      {children}
    </AccountContext.Provider>
  );
};

export const AccountConsumer = AccountContext.Consumer;
