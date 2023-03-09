namespace Eventi.Application.Contract.Role;

public class CreateRole
{
    public string Name { get; set; }
    public List<int> Permissions { get; set; }
}