namespace Eventi.Application.Contract.Account;

public class AccountSearchModel
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public long RoleId { get; set; }
    public string NationalCode { get; set; }
}