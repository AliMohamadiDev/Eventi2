using _0_Framework.Application;
using Eventi.Application.Contract.DiscountCode;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class DiscountCodeApplication : IDiscountCodeApplication
{
    private readonly IDiscountCodeRepository _discountCodeRepository;

    public DiscountCodeApplication(IDiscountCodeRepository discountCodeRepository)
    {
        _discountCodeRepository = discountCodeRepository;
    }

    public async Task<EditDiscountCode?> GetDetailsAsync(long id)
    {
        return await _discountCodeRepository.GetDetailsAsync(id);
    }

    public async Task<List<DiscountCodeViewModel>> GetDiscountCodesAsync()
    {
        return await _discountCodeRepository.GetDiscountCodesAsync();
    }

    public async Task<OperationResult> EditDiscountCodeAsync(EditDiscountCode command)
    {
        var operation = new OperationResult();
        var discountCode = _discountCodeRepository.GetDiscountCode(command.Id);

        discountCode.Edit(command.Code, command.DiscountRate, command.Count, command.TicketId);

        await _discountCodeRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateDiscountCodeAsync(CreateDiscountCode command)
    {
        var operation = new OperationResult();

        var discountCode = new DiscountCode(command.Code, command.DiscountRate, command.Count, command.TicketId);

        await _discountCodeRepository.CreateAsync(discountCode);
        await _discountCodeRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<DiscountCodeViewModel>> SearchAsync(DiscountCodeSearchModel searchModel)
    {
        return await _discountCodeRepository.SearchAsync(searchModel);
    }
}