import { useField } from 'formik';
import React from 'react';
import Select from 'react-select';

import { customStyles } from './customStyles';
import { IFormikSelectProps } from './interfaces/IFormikSelectProps';

export const FormikSelect: React.FC<IFormikSelectProps> = ({ label, ...props }) => {
  const [field, meta, { setValue, setTouched }] = useField(props);
  const options = props.children.map((option) => ({
    value: option.props.value,
    label: option.props.children,
  }));

  const onBlur = (e: React.FocusEvent) => {
    setTouched(false);
  };

  const onChange = ({ value }: any) => {
    setValue(value);
  };

  return (
    <React.Fragment>
      <label htmlFor={props.id ?? `dpn-${props.name}`} className="form-label">
        {label}
      </label>
      <Select
        defaultValue={options.find((option) => option.value === field.value)}
        options={options}
        onChange={onChange}
        onBlur={onBlur}
        styles={customStyles}
        id={props.id ?? `dpn-${props.name}`}
      />
      {meta.touched && meta.error ? (
        <div className="form-text text-danger">{meta.error}</div>
      ) : null}
    </React.Fragment>
  );
};
