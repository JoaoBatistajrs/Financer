﻿namespace FinancialManager.Domain.Interfaces
{
    public interface IPagedBaseResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalRegisters { get; set; } 
    }
}