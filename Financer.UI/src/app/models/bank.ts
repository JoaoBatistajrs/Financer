export interface Bank {
  id: number;
  name: string;
  agency?: string;
  accountNumber?: string;
  accountBalance: number;
}

export interface BankModelCreate {
  name: string;
  group?: string | null;
}
