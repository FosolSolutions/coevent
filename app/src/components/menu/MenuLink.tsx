import { applyStatics, MenuItem, MenuItemProps } from '@szhsin/react-menu';
import { useHistory } from 'react-router-dom';

/**
 * MenuLink properties.
 */
export interface IMenuLinkProps extends MenuItemProps {
  /**
   * URL route path.
   */
  to: string;
}

/**
 * MenuLink provides a menu link component that uses React Router.
 * @param param0 Properties of component.
 * @returns MenuLink component.
 */
export const MenuLink: React.FC<IMenuLinkProps> = ({ to, ...rest }) => {
  const history = useHistory();

  return (
    <MenuItem
      href={to}
      onClick={(e) => {
        e.syntheticEvent.preventDefault();
        history.push(to);
      }}
      {...rest}
    ></MenuItem>
  );
};

applyStatics(MenuItem)(MenuLink);
