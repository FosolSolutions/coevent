import { useFormikContext } from 'formik';

import { AutoComplete, IAutoCompleteProps } from '..';
import * as styled from './FormikAutoCompleteStyled';

export interface IFormikAutoCompleteProps extends IAutoCompleteProps {
  name: string;
  label?: string;
  value?: string | number | readonly string[];
}

export const FormikAutoComplete = <T extends any>({
  id,
  name,
  label,
  value,
  onChange,
  onBlur,
  children,
  className,
  ...rest
}: IFormikAutoCompleteProps) => {
  const { values, errors, touched, handleBlur, handleChange, isSubmitting } = useFormikContext<T>();
  const error = (errors as any)[name] && (touched as any)[name] && (errors as any)[name];
  return (
    <styled.FormikAutoComplete>
      {label && <label htmlFor={`dpn-${name}`}>{label}</label>}
      <div>
        <AutoComplete
          id={id ?? `dpn-${name}`}
          name={name}
          value={value ?? (values as any)[name] ?? ''}
          onChange={onChange ?? handleChange}
          onBlur={onBlur ?? handleBlur}
          className={error ? `${className} error` : className}
          disabled={isSubmitting}
          {...rest}
        >
          {children}
        </AutoComplete>
        {error ? <p role="alert">{error}</p> : null}
      </div>
    </styled.FormikAutoComplete>
  );
};
