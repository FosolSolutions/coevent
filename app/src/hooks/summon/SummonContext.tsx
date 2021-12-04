import React from 'react';

import { ISummonProviderProps, ISummonState } from '.';

/**
 * SummonContext, provides shared state between AJAX requests.
 */
export const SummonContext = React.createContext<ISummonState>({
  setToken: () => {},
});

/**
 * SummonProvider, provides a way to initialize context.
 * @param param0 SummonProvider initialization properties.
 * @returns
 */
export const SummonProvider: React.FC<ISummonProviderProps> = ({ token: initToken, children }) => {
  const [token, setToken] = React.useState<string | null | undefined>(initToken);
  return <SummonContext.Provider value={{ token, setToken }}>{children}</SummonContext.Provider>;
};

export const SummonConsumer = SummonContext.Consumer;
