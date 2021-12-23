import { MenuStatus } from 'components/menu';
import React from 'react';

import { Footer, Header, Loading, MenuProvider } from '..';
import * as styled from './LayoutStyled';

interface ILayoutProps extends React.HTMLAttributes<HTMLDivElement> {
  /**
   * Site name to display in header.
   */
  name: string;
}

/**
 * Layout provides a div structure to organize the page.
 * @param param0 Div element attributes.
 * @returns Layout component.
 */
export const Layout: React.FC<ILayoutProps> = ({ name, children, ...rest }) => {
  const [isLoading] = React.useState(false);

  return (
    <styled.Layout {...rest}>
      <MenuProvider status={MenuStatus.full}>
        <Header name={name} />
        <main>
          {children}
          {isLoading && <Loading />}
        </main>
        <Footer />
      </MenuProvider>
    </styled.Layout>
  );
};
