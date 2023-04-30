namespace _01_EventiQuery.Contracts.Common;

public interface IIndexQuery
{
    int AccountsCount();
    int OrdersCount();
    int ArticlesCount();
    int DepartmentsCount();
}