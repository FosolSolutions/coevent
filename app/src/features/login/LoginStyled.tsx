import styled from 'styled-components';

export const Login = styled.div`
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: center;
  align-content: center;
  gap: 2rem;
  align-items: center;
  height: 100%;

  > div:first-child {
    display: flex;
    flex-direction: row;
    flex-flow: wrap;
    align-items: center;
    justify-content: center;
    height: 20rem;
    width: 40rem;
    border-radius: 0.5rem;
    background: white;
    padding: 1rem;
    gap: 0;

    > * {
    }
  }

  input {
    min-width: 36ch;
  }
`;

export default Login;
