import {
  Button,
  ButtonVariant,
  castEnumToOptions,
  FormikAutoComplete,
  FormikCheckbox,
  FormikDropdown,
  FormikText,
  FormikTextArea,
  Option,
} from 'components';
import { Formik } from 'formik';
import { AccountTypes, IAccountModel, useApi } from 'hooks';
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
    } else {
      setAccount(defaultAccount);
    }
  }, [api, id]);

  const handleDelete = async () => {
    await api.accounts.remove(toModel(account));
    await new Promise((r) => setTimeout(r, 30 * 1000));
    navigate('/admin/accounts');
  };

  return (
    <styled.Account>
      <div>
        <h1>Account</h1>
        <div>
          <Button variant={ButtonVariant.success} onClick={() => navigate('/admin/accounts/0')}>
            Add New
          </Button>
        </div>
      </div>
      <div>
        <Formik
          enableReinitialize
          initialValues={account}
          validate={(values) => {
            const errors = {} as any;
            if (!values.name) errors.name = 'Required';
            return errors;
          }}
          onSubmit={async (values, { setSubmitting }) => {
            let data: IAccountModel;
            if (values.id === 0) {
              data = await api.accounts.add(toModel(values));
            } else {
              data = await api.accounts.update(toModel(values));
            }
            setAccount(toForm(data));
            setSubmitting(false);
            navigate(`/admin/accounts/${data.id}`);
          }}
        >
          {({ values, handleSubmit, isSubmitting, setSubmitting }) => (
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
                  options={[
                    Option.create('Admin', 1),
                    Option.create('Fake 1', 2),
                    Option.create('Fake 2', 3),
                  ]}
                  autoComplete="on"
                ></FormikAutoComplete>
              </div>
              <div>
                <Button type="submit" variant={ButtonVariant.primary} disabled={isSubmitting}>
                  Save
                </Button>
                <Button
                  variant={ButtonVariant.danger}
                  onClick={async () => {
                    setSubmitting(true);
                    await handleDelete();
                    setSubmitting(false);
                  }}
                  disabled={isSubmitting}
                >
                  Delete
                </Button>
                <Button
                  variant={ButtonVariant.secondary}
                  onClick={() => navigate('/admin/accounts')}
                  disabled={isSubmitting}
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
