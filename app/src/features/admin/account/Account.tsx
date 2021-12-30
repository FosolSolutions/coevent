import {
  Button,
  ButtonVariant,
  castEnumToOptions,
  FormikAutoComplete,
  FormikCheckbox,
  FormikDropdown,
  FormikText,
  FormikTextArea,
} from 'components';
import { Formik } from 'formik';
import { AccountTypes, useApi } from 'hooks';
import React from 'react';
import { useNavigate, useParams } from 'react-router-dom';

import { defaultAccount, IAccount, toForm, toModel } from '.';
import * as styled from './styled';

/**
 * Account component properties.
 */
export interface IAccountProps {
  /**
   * Primary key to identify the account.
   */
  id?: number;
}

export const Account: React.FC<IAccountProps> = ({ id }) => {
  const params = useParams();
  id = parseInt(params.id ?? `${id}`);
  const api = useApi();
  const [account, setAccount] = React.useState<IAccount>(defaultAccount);
  const navigate = useNavigate();

  React.useEffect(() => {
    if (id) {
      api.accounts.get(id).then((data) => {
        setAccount(toForm(data));
      }); // TODO: Handle error.
    }
  }, [api, id]);

  return (
    <styled.Account>
      <h1>Account</h1>
      <div>
        <Formik
          enableReinitialize
          initialValues={account}
          validate={(values) => {
            const errors = {} as any;
            if (!values.name) errors.name = 'Required';
            return errors;
          }}
          onSubmit={(values, { setSubmitting }) => {
            api.accounts.update(toModel(values)).then((data) => {
              setAccount(toForm(data));
              setSubmitting(false);
            }); // TODO: Handle error.
          }}
        >
          {({ values, handleChange, handleBlur, handleSubmit, isSubmitting }) => (
            <form onSubmit={handleSubmit}>
              <div>
                <FormikText name="name" label="Name:" value={values.name} required></FormikText>
                <FormikTextArea
                  name="description"
                  label="Description:"
                  value={values.description}
                ></FormikTextArea>
                <FormikCheckbox
                  name="isDisabled"
                  label="Disabled:"
                  checked={values.isDisabled}
                ></FormikCheckbox>
                <FormikDropdown
                  name="accountType"
                  label="Type:"
                  required
                  options={castEnumToOptions(AccountTypes)}
                ></FormikDropdown>
                <FormikAutoComplete
                  name="ownerId"
                  label="Owner:"
                  required
                  options={['Admin']}
                ></FormikAutoComplete>
              </div>
              <div>
                <Button type="submit" variant={ButtonVariant.primary} disabled={isSubmitting}>
                  Save
                </Button>
                <Button
                  variant={ButtonVariant.secondary}
                  onClick={() => navigate('/admin/accounts')}
                >
                  Cancel
                </Button>
              </div>
            </form>
          )}
        </Formik>
      </div>
    </styled.Account>
  );
};
