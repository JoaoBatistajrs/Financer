using FinancialManager.Domain.Enum;
using FinancialManager.Domain.Models;

namespace FinancialManager.Tests
{
    public class BankTests
    {
        [Fact]
        public void Bank_Constructor_WithParameters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string name = "Bank of Finance";
            string agency = "1234";
            string accountNumber = "567890";
            AccountTypeEnum accountType = AccountTypeEnum.Bank;

            // Act
            var bank = new Bank(name, agency, accountNumber, accountType);

            // Assert
            Assert.Equal(name, bank.Name);
            Assert.Equal(agency, bank.Agency);
            Assert.Equal(accountNumber, bank.AccountNumber);
            Assert.Equal(accountType, bank.AccountType);
            Assert.Empty(bank.Registers);
        }

        [Fact]
        public void Bank_Constructor_WithId_ShouldSetIdAndPropertiesCorrectly()
        {
            // Arrange
            int id = 1;
            string name = "Bank of Finance";
            string agency = "1234";
            string accountNumber = "567890";
            AccountTypeEnum accountType = AccountTypeEnum.Wallet;

            // Act
            var bank = new Bank(id, name, agency, accountNumber, accountType);

            // Assert
            Assert.Equal(id, bank.Id);
            Assert.Equal(name, bank.Name);
            Assert.Equal(agency, bank.Agency);
            Assert.Equal(accountNumber, bank.AccountNumber);
            Assert.Equal(accountType, bank.AccountType);
        }
    }
}