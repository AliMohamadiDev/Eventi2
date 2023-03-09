using Eventi.Domain.AccountAgg;

namespace Eventi.Domain.EventAgg;

public class DepartmentAccount
{
    public long DepartmentId { get; private set; }
    public Department Department { get; private set; }

    public long AccountId { get; private set; }
    public Account Account { get; private set; }
}