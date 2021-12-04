export interface ISummonState {
  /**
   * Cancel token
   */
  token?: string | null;
  setToken: React.Dispatch<React.SetStateAction<string | null | undefined>>;
}
