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

            // Act
            var bank = new Bank(name, agency, accountNumber);

            // Assert
            Assert.Equal(name, bank.Name);
            Assert.Equal(agency, bank.Agency);
            Assert.Equal(accountNumber, bank.AccountNumber);
        }
    }
}