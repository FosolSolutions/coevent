import { defaultEnvelope, LifecycleToasts, useSummon } from 'hooks';

import { Settings, useApiAuth } from '.';

/**
 * Common hook to make requests to the PIMS APi.
 * @returns CustomAxios object setup for the PIMS API.
 */
export const useApi = (
  options: {
    lifecycleToasts?: LifecycleToasts;
    selector?: Function;
    envelope?: typeof defaultEnvelope;
    baseURL?: string;
  } = {},
) => {
  const summon = useSummon({ ...options, baseURL: options.baseURL ?? Settings.ApiPath });
  const auth = useApiAuth();

  return {
    ...summon,
    auth,
  };
};

export default useApi;
