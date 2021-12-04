import { NavMenu } from 'components';
import { Layout } from 'components';
import { AppRouter } from 'components/router';
import { AccountProvider, SummonProvider } from 'hooks';
import { BrowserRouter } from 'react-router-dom';
import ReactTooltip from 'react-tooltip';

function App() {
  const name = 'Coevent';

  return (
    <AccountProvider>
      <SummonProvider>
        <BrowserRouter basename={process.env.PUBLIC_URL}>
          <Layout name={name}>{{ menu: <NavMenu />, router: <AppRouter /> }}</Layout>
        </BrowserRouter>

        <ReactTooltip id="main-tooltip" effect="float" type="light" place="top" />
        <ReactTooltip id="main-tooltip-right" effect="solid" type="light" place="right" />
      </SummonProvider>
    </AccountProvider>
  );
}

export default App;
