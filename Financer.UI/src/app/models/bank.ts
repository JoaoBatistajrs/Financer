export interface Bank {
  id: number;
  name: string;
  agency: string;
  accountnumber: string;
}

export interface BankModelCreate {
  name: string;
  group?: string | null;
}
