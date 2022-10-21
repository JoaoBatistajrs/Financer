namespace FinancialManager.Domain.Interfaces
{
    public interface IUser
    {
        public int Id { get;  set; }
        public string Email { get;  set; }
        public string PassWord { get;  set; }
    }
}
