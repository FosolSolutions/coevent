import { IOption } from 'components';
import { SelectHTMLAttributes } from 'react';

import { AutoCompleteVariant } from '..';

export interface IAutoCompleteProps extends SelectHTMLAttributes<HTMLSelectElement> {
  /**
   * The styled variant.
   */
  variant?: AutoCompleteVariant;
  /**
   * The tooltip to show on hover.
   */
  tooltip?: string;
  /**
   * An array of options.
   */
  options?: readonly string[] | number[] | IOption[];
}
