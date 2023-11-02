using _0_Framework.Application;
using Eventi.Application.Contract.EventSubcategory;
using Eventi.Domain.EventCategoryAgg;

namespace Eventi.Application;

public class EventSubcategoryApplication : IEventSubcategoryApplication
{
    private readonly IEventSubcategoryRepository _eventSubcategoryRepository;

    public EventSubcategoryApplication(IEventSubcategoryRepository eventSubcategoryRepository)
    {
        _eventSubcategoryRepository = eventSubcategoryRepository;
    }

    public async Task<OperationResult> CreateAsync(CreateEventSubcategory command)
    {
        var operation = new OperationResult();
        if (_eventSubcategoryRepository.Exists(x => x.SubcategoryName == command.SubcategoryName))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var slug = command.SubcategoryName.Slugify();

        var eventSubcategory = new EventSubcategory(command.SubcategoryName, slug);

        await _eventSubcategoryRepository.CreateAsync(eventSubcategory);
        await _eventSubcategoryRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> EditAsync(EditEventSubcategory command)
    {
        var operation = new OperationResult();
        var eventSubcategory = await _eventSubcategoryRepository.GetAsync(command.SubcategoryId);
        if (eventSubcategory == null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        if (_eventSubcategoryRepository.Exists(x =>
                x.SubcategoryName == command.SubcategoryName && x.SubcategoryId != command.SubcategoryId))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var slug = command.SubcategoryName.Slugify();

        eventSubcategory.Edit(command.SubcategoryName, slug);

        await _eventSubcategoryRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<EditEventSubcategory?> GetDetailsAsync(long id)
    {
        return await _eventSubcategoryRepository.GetDetailsAsync(id);
    }

    public async Task<List<EventSubcategoryViewModel>> GetEventSubcategoriesAsync()
    {
        return await _eventSubcategoryRepository.GetEventSubcategoriesAsync();
    }

    public async Task<List<EventSubcategoryViewModel>> SearchAsync(EventSubcategorySearchModel searchModel)
    {
        return await _eventSubcategoryRepository.SearchAsync(searchModel);
    }
}