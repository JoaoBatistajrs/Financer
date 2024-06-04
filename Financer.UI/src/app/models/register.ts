export interface Register {
  id: number;
  description: string;
  date: Date;
  bankName: string;
  categoryName: string;
  amount: number;
  registerTypeName: string;
}

export interface RegisterCreate {
  id: number;
  description: string;
  date: Date;
  bankId: number;
  categoryId: number;
  amount: number;
  registerTypeId: number;
  bankName: string;
  categoryName: string;
  registerTypeName: string;
}


