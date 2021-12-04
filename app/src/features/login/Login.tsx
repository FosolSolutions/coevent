import { Button, Text } from 'components';
import { Formik } from 'formik';
import { useAccount, useApi } from 'hooks';
import { useHistory } from 'react-router';

import { IParticipantLoginForm } from './interfaces';
import * as styled from './LoginStyled';

/**
 * Login will display content for an anonymous user.
 * If the user is already authenticated it will redirect to the home route.
 * @returns Login component.
 */
export const Login = () => {
  const auth = useAccount();
  const api = useApi();
  const history = useHistory();

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
            onSubmit={async (values, { setSubmitting }) => {
              try {
                if (!!values.key) {
                  var token = await api.loginAsParticipant({ key: values.key });
                  auth.login(token);
                  history.push('/');
                  setSubmitting(false);
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
