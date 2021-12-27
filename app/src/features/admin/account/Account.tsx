import React from 'react';
import { useParams } from 'react-router-dom';

export const Account: React.FC = () => {
  const { id } = useParams();

  return <div>Account: {id}</div>;
};
