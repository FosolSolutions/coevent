import { PrivateRoute } from 'components';
import {
  Accounts,
  Calendar,
  Calendars,
  Draft,
  Home,
  Login,
  NotFound,
  Schedule,
  Users,
} from 'features';
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
      <PrivateRoute path="/admin/calendars" claims={Claim.administrator} component={Calendars} />
      <PrivateRoute path="/admin/accounts" claims={Claim.administrator} component={Accounts} />
      <PrivateRoute path="/admin/users" claims={Claim.administrator} component={Users} />
      <PrivateRoute path="/admin/roles" claims={Claim.administrator} component={Draft} />
      <PrivateRoute path="/calendar" component={Calendar} />
      <PrivateRoute path="/schedule" component={Schedule} />
      <PrivateRoute path="/" exact component={Home} />
      <Route path="*" exact component={NotFound} />
    </Switch>
  );
};
