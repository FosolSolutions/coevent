import { PrivateRoute } from 'components';
import { Home, Login, NotFound } from 'features';
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
      <PrivateRoute path="/" component={Home} />
      <Route path="*" exact component={NotFound} />
    </Switch>
  );
};
