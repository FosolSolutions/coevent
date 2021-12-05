import { MenuStatus } from 'components/menu';
import React from 'react';

import { Footer, Header, Loading, MenuProvider } from '..';
import * as styled from './LayoutStyled';

interface ILayoutProps extends React.HTMLAttributes<HTMLDivElement> {
  /**
   * Site name to display in header.
   */
  name: string;
  children: {
    menu: React.ReactNode;
    router: React.ReactNode;
  };
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
        <div className="main-window">
          <main>
            {children.router}
            {isLoading && <Loading />}
          </main>
        </div>
        <Footer />
      </MenuProvider>
    </styled.Layout>
  );
};
