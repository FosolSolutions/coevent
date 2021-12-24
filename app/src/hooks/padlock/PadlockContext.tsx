import moment from 'moment';
import React from 'react';
import { useCookies } from 'react-cookie';

import { IPadlockProviderProps, IPadlockState, IToken, IUserInfo } from './interfaces';

/**
 * PadlockContext, provides shared state between AJAX requests.
 */
export const PadlockContext = React.createContext<IPadlockState>({
  authReady: false,
  setAuthReady: () => {},
  authenticated: false,
  setAuthenticated: () => {},
  setToken: () => {},
  setUserInfo: () => {},
});

/**
 * PadlockProvider, provides a way to initialize context.
 * @param param0 PadlockProvider initialization properties.
 * @returns
 */
export const PadlockProvider: React.FC<IPadlockProviderProps> = ({
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
  const [cookies, setCookies] = useCookies();

  React.useEffect(() => {
    // Configure account authentication solution.
    const token = cookies.token as IToken;
    if (!!token) {
      setToken(token);
      setAuthenticated(moment.unix(token.expiresIn).isAfter(moment.now()));
    }
    setAuthReady(true);
  }, [setAuthReady, cookies, setCookies]);

  return (
    <PadlockContext.Provider
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
    </PadlockContext.Provider>
  );
};

export const PadlockConsumer = PadlockContext.Consumer;
