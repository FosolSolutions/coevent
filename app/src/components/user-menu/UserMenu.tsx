import { useAccount } from 'hooks';

import { Button, ButtonVariant, LogoutButton } from '..';
import * as styled from './styled';

/**
 * UserMenu provides information and actions for the current user.
 * Unauthenticated:
 *  - login button.
 * Authenticated:
 *  - user's identity.
 *  - logout button
 * @returns UserMenu component.
 */
export const UserMenu = () => {
  const auth = useAccount();

  return (
    <div>
      {auth.authenticated ? (
        <styled.UserMenu>
          <div>{auth.state.userInfo?.displayName}</div>
          <LogoutButton onClick={() => auth.logout()} size={20} />
        </styled.UserMenu>
      ) : (
        <Button variant={ButtonVariant.warning} onClick={() => null}>
          Login
        </Button>
      )}
    </div>
  );
};
