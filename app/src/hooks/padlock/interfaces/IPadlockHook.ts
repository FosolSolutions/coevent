import { Claim, Role } from 'hooks';

import { IPadlockState, IToken } from '.';

export interface IPadlockHook {
  state: IPadlockState;
  authenticated: boolean;
  login: (token: IToken) => void;
  logout: () => void;
  hasClaim: (claims: Claim | Array<Claim>) => boolean;
  hasRole: (roles: Role | Array<Role>) => boolean;
}
