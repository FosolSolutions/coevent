import { IOption } from './IOption';

export interface IFormikSelectProps {
  label?: string;
  id?: string;
  name: string;
  options: IOption[];
}
