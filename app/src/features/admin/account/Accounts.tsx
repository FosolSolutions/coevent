import { GridTable } from 'components';
import { IAccountModel, useApi } from 'hooks';
import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Row } from 'react-table';

import { columns } from './accountColumns';

/**
 * Accounts component provides a way to list and filter accounts.
 * @returns Account administrative component.
 */
export const Accounts = () => {
  const api = useApi();
  const navigate = useNavigate();
  const [accounts, setAccounts] = React.useState<IAccountModel[]>([]);

  React.useEffect(() => {
    api.accounts.getPage(1).then((results) => setAccounts(results));
  }, [api]);

  return (
    <div>
      <h1>Accounts</h1>
      <div>
        <GridTable
          columns={columns}
          data={accounts}
          onRowClick={(row: Row<IAccountModel>) => navigate(`/admin/accounts/${row.original.id}`)}
        ></GridTable>
      </div>
    </div>
  );
};
