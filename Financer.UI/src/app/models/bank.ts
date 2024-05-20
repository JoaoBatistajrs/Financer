import { AccountTypeEnum } from "../enums/accounttype.enum";

export interface Bank {
  id: number;
  name: string;
  agency?: string;
  accountNumber?: string;
  accountType: AccountTypeEnum;
}

export interface BankModelCreate {
  name: string;
  group?: string | null;
}
