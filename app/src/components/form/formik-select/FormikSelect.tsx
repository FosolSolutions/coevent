import { useFormikContext } from 'formik';
import React from 'react';
import Select from 'react-select';

import { customStyles } from './customStyles';
import * as styled from './FormikSelectStyled';
import { IFormikSelectProps } from './interfaces/IFormikSelectProps';

export const FormikSelect: React.FC<IFormikSelectProps> = ({
  label,
  name,
  options,
  id,
  ...rest
}) => {
  const { values, errors, touched, handleBlur, handleChange, isSubmitting } =
    useFormikContext<IFormikSelectProps>();
  const error = (errors as any)[name] && (touched as any)[name] && (errors as any)[name];

  const onChange = ({ value }: any) => {
    handleChange(name)(value);
  };

  return (
    <styled.FormikSelect>
      <label htmlFor={id ?? `sel-${name}`} className="form-label">
        {label}
      </label>
      <Select
        defaultValue={options.find((option) => option.value === (values as any)[name])}
        options={options}
        onChange={onChange}
        onBlur={handleBlur}
        styles={customStyles}
        id={id ?? `sel-${name}`}
        isDisabled={isSubmitting}
        className={error ? 'error' : ''}
        classNamePrefix="rs"
      />
      {error ? <p role="alert">{error}</p> : null}
    </styled.FormikSelect>
  );
};
