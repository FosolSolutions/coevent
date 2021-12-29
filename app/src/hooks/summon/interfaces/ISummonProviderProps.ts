import React from 'react';

import { ILifecycleToasts } from '.';

export const defaultEnvelope = (x: any) => ({ data: { records: x } });

export interface ISummonProviderProps extends React.HTMLAttributes<HTMLElement> {
  authReady?: boolean;
  lifecycleToasts?: ILifecycleToasts;
  selector?: Function;
  envelope?: typeof defaultEnvelope;
  baseURL?: string;
}
