import { useFormikContext } from 'formik';

import { Checkbox, ICheckboxProps } from '..';
import * as styled from './FormikCheckboxStyled';

export interface IFormikCheckboxProps extends ICheckboxProps {
  name: string;
  label?: string;
  value?: string | number | readonly string[];
  checked?: boolean;
}

export const FormikCheckbox = <T extends any>({
  id,
  name,
  label,
  value,
  onChange,
  onBlur,
  checked,
  className,
  ...rest
}: IFormikCheckboxProps) => {
  const { values, errors, touched, handleBlur, handleChange, isSubmitting } = useFormikContext<T>();
  const error = (errors as any)[name] && (touched as any)[name] && (errors as any)[name];
  return (
    <styled.FormikCheckbox>
      <label htmlFor={id ?? `cbx-${name}`}>{label}</label>
      <div>
        <Checkbox
          id={id ?? `cbx-${name}`}
          name={name}
          value={value ?? (values as any)[name] ?? ''}
          checked={checked}
          onChange={onChange ?? handleChange}
          onBlur={onBlur ?? handleBlur}
          className={error ? `${className} error` : className}
          disabled={isSubmitting}
          {...rest}
        ></Checkbox>
        {error ? <p role="alert">{error}</p> : null}
      </div>
    </styled.FormikCheckbox>
  );
};
