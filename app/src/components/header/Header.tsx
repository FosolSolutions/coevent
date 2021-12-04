import CoeventLogo from 'components/assets/coEventLogoWh.svg';
import SVG from 'react-inlinesvg';

import { UserMenu } from '..';
import * as styled from './HeaderStyled';

interface IHeaderProps extends React.HTMLAttributes<HTMLDivElement> {
  /**
   * The site name.
   */
  name: string;
}

/**
 * Provides a header element.
 * @param param0 Header element attributes.
 * @returns Header component.
 */
export const Header: React.FC<IHeaderProps> = ({ name, children, ...rest }) => {
  return (
    <styled.Header {...rest}>
      <div>
        <a href="/">
          <SVG src={CoeventLogo} />
        </a>
      </div>
      <div>{<UserMenu />}</div>
    </styled.Header>
  );
};
