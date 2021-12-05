import { AccountContext, IAccountHook, IAccountHookProps, IToken } from 'hooks';
import React from 'react';
import { useCookies } from 'react-cookie';

export const useAccount = ({ token }: IAccountHookProps = {}): IAccountHook => {
  const state = React.useContext(AccountContext);
  const [, setCookies] = useCookies();

  const storeToken = React.useCallback(
    (token: IToken | null) => {
      setCookies('token', token, { path: '/' });
    },
    [setCookies],
  );

  React.useEffect(() => {
    if (!!token) {
      state.setToken(token);
      state.setAuthenticated(true);
      storeToken(token);
    }
  }, [state, token, storeToken]);

  const login = React.useCallback(
    (token: IToken) => {
      state.setToken(token);
      state.setAuthenticated(true);
      storeToken(token);
    },
    [state, storeToken],
  );

  const logout = React.useCallback(() => {
    storeToken(null);
    state.setToken(null);
    state.setAuthenticated(false);
  }, [state, storeToken]);

  return {
    state,
    authenticated: state.authenticated,
    login,
    logout,
  };
};
