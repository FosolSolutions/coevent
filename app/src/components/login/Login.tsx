import { useHistory } from 'react-router-dom';

/**
 * Login will display content for an anonymous user.
 * If the user is already authenticated it will redirect to the home route.
 * @returns Login component.
 */
export const Login = () => {
  const history = useHistory();

  history.push('/');
  return <div>Anonymous user</div>;
};
