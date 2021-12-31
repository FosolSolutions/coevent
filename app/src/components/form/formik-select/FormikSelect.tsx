import { useField } from 'formik';
import React from 'react';
import Select, { StylesConfig } from 'react-select';

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

  const customStyles: StylesConfig = {
    control: (provided, state) => ({
      ...provided,
      background: '#f2f2f2',
      borderColor: '#38598a',
      width: 200,
      boxShadow: state.isFocused ? '0 0 0 0.2rem rgb(86 114 156 / 50%)' : 'none',

      '&:hover': {
        borderColor: '#38598a',
      },
    }),
    menu: (provided, state) => ({
      ...provided,
      width: 200,
    }),
    option: (provided, state) => ({
      ...provided,
      background: state.isSelected ? '#848884' : state.isFocused ? '#ddd' : 'transparent',

      '&:hover': {
        background: state.isSelected ? '#848884' : '#ddd',
      },
    }),
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
