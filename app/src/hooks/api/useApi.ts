import { defaultEnvelope, ITokenModel, LifecycleToasts, useSummon } from 'hooks';

import { IParticipantLoginModel, Settings } from '.';

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

  const loginAsParticipant = async (model: IParticipantLoginModel): Promise<ITokenModel> => {
    try {
      const response = await summon.post(`/auth/participants/token`, model);
      return response.data as ITokenModel;
    } catch (error) {
      // Handle error;
      return Promise.reject(error);
    }
  };
  return {
    loginAsParticipant,
  };
};

export default useApi;
