import { Button, FormikText } from 'components';
import { Formik } from 'formik';
import { useApi, usePadlock } from 'hooks';
import { useNavigate } from 'react-router-dom';

import { IParticipantLoginForm, IUserLoginForm } from '.';
import * as styled from './LoginStyled';

/**
 * Login will display content for an anonymous user.
 * If the user is already authenticated it will redirect to the home route.
 * @returns Login component.
 */
export const Login = () => {
  const auth = usePadlock();
  const api = useApi();
  const navigate = useNavigate();
  const redirect_uri = new URLSearchParams(window.location.search).get('redirect_uri');

  const defaultParticipantValues: IParticipantLoginForm = { key: '' };
  const defaultUserValues: IUserLoginForm = { username: '', password: '' };

  return (
    <styled.Login>
      <div>
        <div>
          <Formik
            initialValues={defaultParticipantValues}
            onSubmit={async (values) => {
              try {
                if (values.key) {
                  const token = await api.auth.loginAsParticipant({ key: values.key });
                  auth.login(token);
                  navigate(redirect_uri ?? '/');
                }
              } catch (error) {
                // Handle error
              }
            }}
          >
            {({ values, handleChange, handleBlur, handleSubmit, isSubmitting }) => (
              <form onSubmit={handleSubmit}>
                <FormikText
                  name="key"
                  label="Participant Code:"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.key}
                  placeholder="Enter your key"
                ></FormikText>
                <Button type="submit" disabled={isSubmitting}>
                  Login
                </Button>
              </form>
            )}
          </Formik>
        </div>
        <div>Or login with your user account</div>
        <div>
          <Formik
            initialValues={defaultUserValues}
            onSubmit={async (values) => {
              try {
                if (values.username && values.password) {
                  const token = await api.auth.login({
                    username: values.username,
                    password: values.password,
                  });
                  auth.login(token);
                  navigate(redirect_uri ?? '/');
                }
              } catch (error) {
                // Handle error
              }
            }}
          >
            {({ values, handleChange, handleBlur, handleSubmit, isSubmitting }) => (
              <form onSubmit={handleSubmit}>
                <FormikText
                  name="username"
                  label="Username:"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.username}
                  placeholder="Enter your username"
                ></FormikText>
                <FormikText
                  name="password"
                  type="password"
                  label="Password:"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.password}
                  placeholder="Enter your password"
                ></FormikText>
                <Button type="submit" disabled={isSubmitting}>
                  Login
                </Button>
              </form>
            )}
          </Formik>
        </div>
        <div>
          <p>Scheduling for teams</p>
        </div>
      </div>
    </styled.Login>
  );
};
