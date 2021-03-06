import axios from 'axios';
import { Claim, Role, usePadlock } from 'hooks';
import React from 'react';
import { Navigate, RouteProps } from 'react-router-dom';

interface IPrivateRouteProps extends RouteProps {
  /**
   * The path to redirect to if user is unauthorized.
   */
  loginPath?: string;
  /**
   * A role the user belongs to.
   */
  roles?: Role | Array<Role>;
  /**
   * A claim the user has.
   */
  claims?: Claim | Array<Claim>;
  /**
   * The element to load if authorized.
   */
  element?: React.ReactElement | null;
  /**
   * The children elements to load if authorized.
   */
  children?: React.ReactNode;
}

/**
 * PrivateRoute provides a way to only show menu items for authenticated users.
 * @param param0 Route element attributes.
 * @returns PrivateRoute component.
 */
export const PrivateRoute = ({
  loginPath = '/login',
  claims,
  roles,
  element,
  children,
}: IPrivateRouteProps) => {
  const auth = usePadlock();

  if (!auth.authReady) <></>;

  if (
    !auth.authenticated ||
    (!!claims && !auth.hasClaim(claims)) ||
    (!!roles && !auth.hasRole(roles))
  ) {
    const query = {
      redirect_uri: window.location.pathname,
    };
    const path = axios.getUri({ url: loginPath, params: query });
    return <Navigate to={path} />;
  }

  return element || <>{children}</>;
};
