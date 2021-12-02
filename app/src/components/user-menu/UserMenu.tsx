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
  return (
    <div>
      {false ? (
        <styled.UserMenu>
          <div>display name</div>
          <LogoutButton onClick={() => null} size={20} />
        </styled.UserMenu>
      ) : (
        <Button variant={ButtonVariant.warning} onClick={() => null}>
          Login
        </Button>
      )}
    </div>
  );
};
