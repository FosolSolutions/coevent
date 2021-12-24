import { Layout } from 'components';
import { AppRouter } from 'components/router';
import { PadlockProvider, SummonProvider } from 'hooks';
import { CookiesProvider } from 'react-cookie';
import { BrowserRouter } from 'react-router-dom';
import ReactTooltip from 'react-tooltip';

function App() {
  const name = 'Coevent';

  return (
    <CookiesProvider>
      <PadlockProvider>
        <SummonProvider>
          <BrowserRouter basename={process.env.PUBLIC_URL}>
            <Layout name={name}>
              <AppRouter />
            </Layout>
          </BrowserRouter>

          <ReactTooltip id="main-tooltip" effect="float" type="light" place="top" />
          <ReactTooltip id="main-tooltip-right" effect="solid" type="light" place="right" />
        </SummonProvider>
      </PadlockProvider>
    </CookiesProvider>
  );
}

export default App;
