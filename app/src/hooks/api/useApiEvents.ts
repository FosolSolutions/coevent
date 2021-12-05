import { IEventModel, useApi } from '.';

/**
 * Common hook to make requests to the PIMS APi.
 * @returns CustomAxios object setup for the PIMS API.
 */
export const useApiEvents = () => {
  const api = useApi();

  const get = async (id: number): Promise<IEventModel> => {
    try {
      const response = await api.get(`/admin/events/${id}`);
      return response.data as IEventModel;
    } catch (error) {
      // Handle error;
      return Promise.reject(error);
    }
  };

  return {
    get,
  };
};

export default useApiEvents;
