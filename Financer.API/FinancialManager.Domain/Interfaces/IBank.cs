﻿namespace FinancialManager.Domain.Interfaces
{
    public interface IBank
    {
        public string Name { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
    }
}
