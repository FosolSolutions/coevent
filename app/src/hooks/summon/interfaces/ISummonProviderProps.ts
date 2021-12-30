import { IPadlockProps } from 'hooks';
import React from 'react';

import { ILifecycleToasts } from '.';

export const defaultEnvelope = (x: any) => ({ data: { records: x } });

export interface ISummonProviderProps extends IPadlockProps, React.HTMLAttributes<HTMLElement> {
  lifecycleToasts?: ILifecycleToasts;
  selector?: Function;
  envelope?: typeof defaultEnvelope;
}
