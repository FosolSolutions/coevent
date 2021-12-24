import React from 'react';

import { useAccounts, useAuth, useBase, useEvents } from '.';

/**
 * Common hook to make requests to the PIMS APi.
 * @returns CustomAxios object setup for the PIMS API.
 */
export const useApi = () => {
  const base = useBase();
  const auth = useAuth();
  const accounts = useAccounts();
  const events = useEvents();

  return React.useMemo(
    () => ({
      ...base,
      auth,
      accounts,
      events,
    }),
    [base, auth, events, accounts],
  );
};

export default useApi;
