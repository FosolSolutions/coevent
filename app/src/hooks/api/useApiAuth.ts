import { IParticipantLoginModel, ITokenModel, useApi } from '.';

/**
 * Common hook to make requests to the PIMS APi.
 * @returns CustomAxios object setup for the PIMS API.
 */
export const useApiAuth = () => {
  const api = useApi();

  const loginAsParticipant = async (model: IParticipantLoginModel): Promise<ITokenModel> => {
    try {
      const response = await api.post(`/auth/participants/token`, model);
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

export default useApiAuth;
