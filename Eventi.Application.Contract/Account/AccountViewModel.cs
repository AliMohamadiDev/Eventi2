namespace Eventi.Application.Contract.Account;

public class AccountViewModel
{
    public long Id { get; set; }
    public string Fullname { get; set; }
    public string Lastname { get; set; }
    public string Mobile { get; set; }
    public string? Email { get; set; }
    public long RoleId { get; set; }
    public string Role { get; set; }
    public string ProfilePhoto { get; set; }
    public string CreationDate { get; set; }
}