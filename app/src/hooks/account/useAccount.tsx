import { AccountContext, IAccountHook, IAccountHookProps, IToken } from 'hooks';
import React from 'react';
import Cookies from 'react-cookie';

export const useAccount = ({ token }: IAccountHookProps = {}): IAccountHook => {
  const state = React.useContext(AccountContext);
  const cookies = new Cookies();

  React.useEffect(() => {
    state.setToken(token);
  }, [state, token]);

  const login = React.useCallback(
    (token: IToken) => {
      state.setToken(token);
      state.setAuthenticated(true);
    },
    [state],
  );

  const logout = React.useCallback(() => {
    state.setToken(null);
    state.setAuthenticated(false);
  }, [state]);

  return {
    state,
    authenticated: state.authenticated,
    login,
    logout,
  };
};
