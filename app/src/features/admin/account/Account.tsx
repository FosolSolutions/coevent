import { IAccountModel, useApi } from 'hooks';
import React from 'react';
import { useParams } from 'react-router-dom';

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
  const [account, setAccount] = React.useState<IAccountModel>({} as IAccountModel);

  React.useEffect(() => {
    api.accounts.get(id ?? 0).then((data) => {
      setAccount(data);
    });
  }, [api]);

  return (
    <div>
      Account: {id}
      <div>Name: {account.name}</div>
    </div>
  );
};
