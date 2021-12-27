import { PrivateRoute } from 'components';
import {
  Account,
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
import { Route, Routes } from 'react-router-dom';

/**
 * AppRouter provides a SPA router to manage routes.
 * @returns AppRouter component.
 */
export const AppRouter = () => {
  return (
    <Routes>
      <Route path="/login" element={<Login />}></Route>
      <Route
        path="/calendar"
        element={<PrivateRoute redirectTo="/login" element={<Calendar />} />}
      />
      <Route
        path="/schedule"
        element={<PrivateRoute redirectTo="/login" element={<Schedule />} />}
      />
      <Route
        path="/admin/calendars"
        element={
          <PrivateRoute redirectTo="/login" claims={Claim.administrator} element={<Calendars />} />
        }
      />
      <Route
        path="/admin/accounts"
        element={
          <PrivateRoute redirectTo="/login" claims={Claim.administrator} element={<Accounts />} />
        }
      />
      <Route
        path="/admin/accounts/:id"
        element={
          <PrivateRoute redirectTo="/login" claims={Claim.administrator} element={<Account />} />
        }
      />
      <Route
        path="/admin/users"
        element={
          <PrivateRoute redirectTo="/login" claims={Claim.administrator} element={<Users />} />
        }
      />
      <Route
        path="/admin/roles"
        element={
          <PrivateRoute redirectTo="/login" claims={Claim.administrator} element={<Draft />} />
        }
      />
      <Route path="/" element={<Home />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
};
