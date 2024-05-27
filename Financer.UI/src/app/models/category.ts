export interface Category {
  id: number;
  name: string;
  expenseTypeId: number;
}

export interface CategoryModelCreate {
  name: string;
  expenseTypeId: number;
}
