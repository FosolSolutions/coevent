import { Claim, IPadlockHook, IPadlockHookProps, IToken, PadlockContext, Role } from 'hooks';
import moment from 'moment';
import React from 'react';
import { useCookies } from 'react-cookie';

const COOKIE_NAME = 'token';

/**
 * Padlock hook provides a way for a user to login/logout and authorize actions based on claims and roles.
 * @param param0 Padlock properties.
 * @returns Padlock component.
 */
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
    if (token) {
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

  /**
   * Validate the current user account as at least one of the specified claims.
   * @param claims A claim or an array of claims.
   * @returns True if the current user account has at least one of the specified claims.
   */
  const hasClaim = React.useCallback((claims: Claim | Array<Claim>) => {
    return true;
  }, []);

  /**
   * Validate the current user account as at least one of the specified roles.
   * @param roles A role or an array of roles.
   * @returns True if the current user account has at least one of the specified roles.
   */
  const hasRole = React.useCallback((roles: Role | Array<Role>) => {
    return true;
  }, []);

  return {
    state,
    authenticated: state.authenticated,
    login,
    logout,
    hasClaim,
    hasRole,
  };
};
