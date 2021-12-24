import { IAccountModel } from 'hooks/api';
import { Column } from 'react-table';

export const tableColumns: Column<IAccountModel>[] = [
  {
    Header: 'Name',
    accessor: 'name',
  },
  {
    Header: 'Description',
    accessor: 'description',
  },
  {
    Header: 'Type',
    accessor: 'accountType',
  },
  {
    Header: 'Disabled',
    accessor: 'isDisabled',
  },
];
