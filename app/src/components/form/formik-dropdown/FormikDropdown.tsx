import { useFormikContext } from 'formik';

import { Dropdown, IDropdownProps } from '..';
import * as styled from './FormikDropdownStyled';

export interface IFormikDropdownProps extends IDropdownProps {
  name: string;
  label?: string;
  value?: string | number | readonly string[];
}

export const FormikDropdown = <T extends any>({
  id,
  name,
  label,
  value,
  onChange,
  onBlur,
  children,
  className,
  ...rest
}: IFormikDropdownProps) => {
  const { values, errors, touched, handleBlur, handleChange } = useFormikContext<T>();
  const error = (errors as any)[name] && (touched as any)[name] && (errors as any)[name];
  return (
    <styled.FormikDropdown>
      <label htmlFor={`dpn-${name}`}>{label}</label>
      <div>
        <Dropdown
          id={id ?? `dpn-${name}`}
          name={name}
          value={value ?? (values as any)[name] ?? ''}
          onChange={onChange ?? handleChange}
          onBlur={onBlur ?? handleBlur}
          className={error ? `${className} error` : className}
          {...rest}
        >
          {children}
        </Dropdown>
        {error ? <p role="alert">{error}</p> : null}
      </div>
    </styled.FormikDropdown>
  );
};
