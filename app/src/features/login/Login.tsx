import { Button, Text } from 'components';
import { Formik } from 'formik';
import { useApi, usePadlock } from 'hooks';
import { useNavigate } from 'react-router-dom';

import { IParticipantLoginForm } from './interfaces';
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

  const defaultValues: IParticipantLoginForm = { key: '' };

  return (
    <styled.Login>
      <div>
        <div>
          <label>Participant Code:</label>
        </div>
        <div>
          <Formik
            initialValues={defaultValues}
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
            {({
              values,
              errors,
              touched,
              handleChange,
              handleBlur,
              handleSubmit,
              isSubmitting,
            }) => (
              <form onSubmit={handleSubmit}>
                <Text
                  name="key"
                  onChange={handleChange}
                  onBlur={handleBlur}
                  value={values.key}
                  placeholder="Enter your key"
                ></Text>
                {errors.key && touched.key && errors.key}
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
