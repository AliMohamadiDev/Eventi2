using _0_Framework.Application;

namespace Eventi.Application.Contract.DiscountCode;

public interface IDiscountCodeApplication
{
    Task<EditDiscountCode?> GetDetailsAsync(long id);
    Task<List<DiscountCodeViewModel>> GetDiscountCodesAsync();
    Task<OperationResult> EditDiscountCodeAsync(EditDiscountCode command);
    Task<OperationResult> CreateDiscountCodeAsync(CreateDiscountCode command);
    Task<List<DiscountCodeViewModel>> SearchAsync(DiscountCodeSearchModel searchModel);
}