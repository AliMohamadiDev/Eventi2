using _0_Framework.Domain;
using Eventi.Application.Contract.DiscountCode;

namespace Eventi.Domain.EventAgg;

public interface IDiscountCodeRepository : IRepository<long, DiscountCode>
{
    DiscountCode GetDiscountCode(long id);
    Task<EditDiscountCode?> GetDetailsAsync(long id);
    Task<List<DiscountCodeViewModel>> GetDiscountCodesAsync();
    Task<List<DiscountCodeViewModel>> SearchAsync(DiscountCodeSearchModel searchModel);
}