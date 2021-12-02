import { Login, PrivateRoute } from 'components';
import { NotFound } from 'features';
import { Home } from 'features/home';
import { Claim } from 'hooks';
import { Route, Switch } from 'react-router-dom';

/**
 * AppRouter provides a SPA router to manage routes.
 * @returns AppRouter component.
 */
export const AppRouter = () => {
  return (
    <Switch>
      <Route path="/login" component={Login}></Route>
      <PrivateRoute path="/admin" claims={Claim.administrator}>
        <p>Administration</p>
      </PrivateRoute>
      <Route path="/" exact={true} component={Home}></Route>
      <Route path="*" exact={true} component={NotFound} />
    </Switch>
  );
};
