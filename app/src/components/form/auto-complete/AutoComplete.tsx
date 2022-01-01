import React from 'react';

import { instanceOfIOption, IOption } from '..';
import { AutoCompleteVariant, IAutoCompleteProps } from '.';
import * as styled from './AutoCompleteStyled';

/**
 * AutoComplete component provides a bootstrapped styled button element.
 * @param param0 AutoComplete element attributes.
 * @returns AutoComplete component.
 */
export const AutoComplete: React.FC<IAutoCompleteProps> = ({
  variant = AutoCompleteVariant.primary,
  tooltip,
  children,
  className,
  options,
  ...rest
}) => {
  return (
    <styled.AutoComplete
      variant={variant}
      {...rest}
      className={`${className}`}
      data-for="main"
      data-tip={tooltip}
    >
      {options
        ? options.map((option) => {
            if (instanceOfIOption(option)) {
              const item = option as IOption;
              return (
                <option key={item.value} value={item.value}>
                  {item.label}
                </option>
              );
            } else {
              const value = option as string;
              return (
                <option key={value} value={value}>
                  {option}
                </option>
              );
            }
          })
        : children}
    </styled.AutoComplete>
  );
};
