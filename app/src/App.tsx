import { NavMenu } from 'components';
import { Layout, LayoutAnonymous, Loading } from 'components';
import { AppRouter } from 'components/router';
import { SummonProvider } from 'hooks';
import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import ReactTooltip from 'react-tooltip';

function App() {
  const name = 'Coevent';

  return (
    <SummonProvider>
      <BrowserRouter basename={process.env.PUBLIC_URL}>
        <Layout name={name}>{{ menu: <NavMenu />, router: <AppRouter /> }}</Layout>
      </BrowserRouter>

      <ReactTooltip id="main-tooltip" effect="float" type="light" place="top" />
      <ReactTooltip id="main-tooltip-right" effect="solid" type="light" place="right" />
    </SummonProvider>
  );
}

export default App;
