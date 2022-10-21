using FinancialManager.Domain.Interfaces;

namespace FinancialManager.Domain.Models
{
    public class User : IUser
    {
        public User(int id, string email, string passWord)
        {
            Id = id;
            Email = email;
            PassWord = passWord;
        }

        public User(string email, string passWord)
        {
            Email = email;
            PassWord = passWord;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
