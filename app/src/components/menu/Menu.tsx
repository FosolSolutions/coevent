import React from 'react';

import * as styled from './styled';

interface IMenuProps extends React.HTMLAttributes<HTMLDivElement> {
  /**
   * Whether to display the icons.
   */
  showIcons?: boolean;
}

/**
 * Menu provides a navigation menu for the application.
 * @param param0 Component properties.
 * @returns Menu component.
 */
export const Menu: React.FC<IMenuProps> = ({ showIcons = true, children, ...rest }) => {
  return <styled.Menu {...rest}>{children}</styled.Menu>;
};
