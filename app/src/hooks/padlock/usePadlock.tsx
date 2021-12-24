import { IPadlockHook, IPadlockHookProps, IToken, PadlockContext } from 'hooks';
import moment from 'moment';
import React from 'react';
import { useCookies } from 'react-cookie';

const COOKIE_NAME = 'token';

export const usePadlock = ({ token }: IPadlockHookProps = {}): IPadlockHook => {
  const state = React.useContext(PadlockContext);
  const [, setCookies, removeCookie] = useCookies();

  const storeToken = React.useCallback(
    (token: IToken | null) => {
      setCookies(COOKIE_NAME, token, { path: '/' });
      state.setToken(token);
      state.setAuthenticated(moment.unix(token?.expiresIn ?? 0).isAfter(moment.now()));
      console.info('authenticated:' + state.authenticated);
    },
    [setCookies, state],
  );

  React.useEffect(() => {
    if (!!token) {
      storeToken(token);
      console.info('token', token);
    }
  }, [token, storeToken]);

  const login = React.useCallback(
    (token: IToken) => {
      storeToken(token);
    },
    [storeToken],
  );

  const logout = React.useCallback(() => {
    removeCookie(COOKIE_NAME);
    storeToken(null);
    state.setToken(null);
    state.setAuthenticated(false);
    console.info('logout');
  }, [state, storeToken, removeCookie]);

  return {
    state,
    authenticated: state.authenticated,
    login,
    logout,
  };
};
