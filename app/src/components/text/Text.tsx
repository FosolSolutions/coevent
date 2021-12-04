import React, { InputHTMLAttributes } from 'react';

import { TextVariant } from '.';
import * as styled from './TextStyled';

export interface ITextProps extends InputHTMLAttributes<HTMLInputElement> {
  /**
   * The styled variant.
   */
  variant?: TextVariant;
  /**
   * The tooltip to show on hover.
   */
  tooltip?: string;
}

/**
 * Text component provides a bootstrapped styled button element.
 * @param param0 Text element attributes.
 * @returns Text component.
 */
export const Text: React.FC<ITextProps> = ({
  variant = TextVariant.primary,
  tooltip,
  children,
  ...rest
}) => {
  return (
    <styled.Text
      type="text"
      variant={variant}
      {...rest}
      className="btn"
      data-for="main"
      data-tip={tooltip}
    >
      {children}
    </styled.Text>
  );
};
