import axios from 'axios';
import { calcRefreshInterval, tokenExpired, usePadlock } from 'hooks';
import { isEmpty, isFunction } from 'lodash';
import React from 'react';
import { toast } from 'react-toastify';

import { defaultEnvelope, ISummonProviderProps, ISummonState } from '.';

/**
 * SummonContext, provides shared state between AJAX requests.
 */
export const SummonContext = React.createContext<ISummonState>({ summon: axios.create() });

/**
 * SummonProvider, provides a way to initialize context.
 * @param param0 SummonProvider initialization properties.
 * @returns
 */
export const SummonProvider: React.FC<ISummonProviderProps> = ({
  baseApiUrl,
  lifecycleToasts,
  selector,
  envelope = defaultEnvelope,
  loginPath = '/login',
  autoRefreshToken = true,
  children,
}) => {
  const auth = usePadlock();
  const { accessToken, refreshToken } = auth?.token ?? {};
  const { token: tokenUrl } = auth?.oidc ?? {};
  const { login, logout } = auth;
  const interval = calcRefreshInterval(accessToken);
  let loadingToastId: React.ReactText | undefined;

  const instance = React.useMemo(() => {
    const instance = axios.create({
      baseURL: baseApiUrl,
      headers: {
        'Access-Control-Allow-Origin': '*',
      },
    });

    return instance;
  }, [baseApiUrl]);

  instance.interceptors.request.use((config) => {
    if (accessToken && !config?.headers?.Authorization) {
      config!.headers!.Authorization = `Bearer ${accessToken}`;
    }
    const cancelTokenSource = axios.CancelToken.source();
    // axios.get('', { cancelToken: cancelTokenSource.token });
    // cancelTokenSource.cancel();

    // TODO: Figure out what this part is all about.
    if (selector !== undefined) {
      const cancelToken = selector({
        token: cancelTokenSource.token,
      });

      if (!isEmpty(cancelToken)) {
        throw new axios.Cancel(JSON.stringify(envelope(cancelToken)));
      }
    }
    if (lifecycleToasts?.loadingToast) {
      loadingToastId = lifecycleToasts.loadingToast();
    }
    return config;
  });

  instance.interceptors.response.use(
    (response) => {
      if (lifecycleToasts?.successToast && response.status < 300) {
        loadingToastId && toast.dismiss(loadingToastId);
        lifecycleToasts.successToast();
      } else if (lifecycleToasts?.errorToast && response.status >= 300) {
        lifecycleToasts.errorToast();
      }
      return response;
    },
    (error) => {
      if (axios.isCancel(error)) {
        return Promise.resolve(error.message);
      }
      if (lifecycleToasts?.errorToast) {
        loadingToastId && toast.dismiss(loadingToastId);
        lifecycleToasts.errorToast();
      }

      // TODO: Handle when requests fail due to authentication.  This should redirect user to login page.
      // TODO: Provide popup dialog to indicate a need to login to access route.
      // TODO: Resolve uncaught promise error resulting from this code.
      if (error!.response!.status === 401) {
        const url = `${window.location.href.replace(window.location.pathname, loginPath)}${
          window.location.search ? '&' : '?'
        }redirect_uri=${window.location.pathname}`;
        window.location.replace(url);
      }

      // TODO: This is not returning the error to an async/await try/catch implementation...
      // const errorMessage =
      //  errorToastMessage || (error.response && error.response.data.message) || String.ERROR;
      return Promise.reject(error);
    },
  );

  /**
   * If the token has expired and there is a valid refresh token, make a request to refresh the access token.
   * Then update padlock state with login.
   * If unable to refresh the token, logout.
   */
  const handleRefresh = React.useCallback(async () => {
    if (accessToken && tokenExpired(accessToken)) {
      let expired = true;
      if (tokenUrl && refreshToken && !tokenExpired(refreshToken)) {
        const response = await instance.post(
          tokenUrl,
          {
            grant_type: 'refresh_token',
            refresh_token: refreshToken,
          },
          {
            headers: {
              Authorization: `Bearer ${refreshToken}`,
            },
          },
        );

        if (response.status === 200) {
          expired = false;
          login(response.data);
        }
      }

      if (expired) {
        logout();
      }
    }
  }, [accessToken, refreshToken, tokenUrl, instance, login, logout]);

  // Create an interval timer that will check to see if the access token needs to be refreshed.
  const refHandleRefresh = React.useRef(handleRefresh);
  refHandleRefresh.current = handleRefresh;
  React.useEffect(() => {
    // TODO: A refresh should only occur if the user is still on the page.  Need an isActive listener.
    if (autoRefreshToken) {
      const timer = setInterval(() => {
        refHandleRefresh.current();
      }, interval);

      return () => {
        clearInterval(timer);
      };
    }
  }, [interval, autoRefreshToken]);

  const props = { summon: instance };

  return (
    <SummonContext.Provider value={props}>
      {children
        ? isFunction(children)
          ? (children as (bag: ISummonProviderProps) => React.ReactNode)(
              props as ISummonProviderProps,
            )
          : children
        : null}
    </SummonContext.Provider>
  );
};

export const SummonConsumer = SummonContext.Consumer;
