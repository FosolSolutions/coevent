import { Menu as HMenu } from '@headlessui/react';
import { Menu, MenuButton, MenuContext, MenuGroup } from 'components';
import { useAccount } from 'hooks';
import React from 'react';
import { FaCalendar, FaHome, FaToolbox } from 'react-icons/fa';
import { Link } from 'react-router-dom';

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
export const NavMenu: React.FC<IMenuProps> = ({ showIcons = true, children, ...rest }) => {
  const { status } = React.useContext(MenuContext);
  const auth = useAccount();

  return auth.authenticated ? (
    <Menu {...rest}>
      <MenuButton label="Home" route="/" status={status} icon={FaHome}></MenuButton>
      <MenuButton label="Schedule" route="/schedule" status={status} icon={FaCalendar}></MenuButton>
      <MenuGroup label="Administration" status={status} icon={FaToolbox}>
        <HMenu.Item as="div">{(props) => <Link to="/admin/accounts">Accounts</Link>}</HMenu.Item>
        <HMenu.Item as="div">{(props) => <Link to="/admin/users">Users</Link>}</HMenu.Item>
        <HMenu.Item as="div">{(props) => <Link to="/admin/schedules">Schedules</Link>}</HMenu.Item>
      </MenuGroup>
      {children}
    </Menu>
  ) : null;
};
