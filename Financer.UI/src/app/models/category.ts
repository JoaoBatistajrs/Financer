export interface Category {
  id: number;
  name: string;
  expenseTypeId: number;
  expenseName: string;
}

export interface CategoryModelCreate {
  name: string;
  expenseTypeId: number;
}
