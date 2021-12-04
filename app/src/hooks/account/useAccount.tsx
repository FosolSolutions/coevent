import { AccountContext, IAccountHook, IAccountHookProps } from 'hooks';
import React from 'react';

export const useAccount = ({ token }: IAccountHookProps = {}): IAccountHook => {
  const state = React.useContext(AccountContext);

  React.useEffect(() => {
    state.setToken(token);
  }, [state, token]);

  return {
    state,
    authenticated: state.authenticated,
  };
};
