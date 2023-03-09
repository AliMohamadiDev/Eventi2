using _0_Framework.Application;
using Eventi.Application.Contract.EventCategory;
using Eventi.Domain.EventCategoryAgg;

namespace Eventi.Application;

public class EventCategoryApplication : IEventCategoryApplication
{
    private readonly IEventCategoryRepository _eventCategoryRepository;

    public EventCategoryApplication(IEventCategoryRepository eventCategoryRepository)
    {
        _eventCategoryRepository = eventCategoryRepository;
    }

    public async Task<OperationResult> CreateAsync(CreateEventCategory command)
    {
        var operation = new OperationResult();
        if (_eventCategoryRepository.Exists(x => x.CategoryName == command.CategoryName))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var slug = command.Slug.Slugify();

        var eventCategory = new EventCategory(command.CategoryName, slug);

        await _eventCategoryRepository.CreateAsync(eventCategory);
        await _eventCategoryRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> EditAsync(EditEventCategory command)
    {
        var operation = new OperationResult();
        var eventCategory = await _eventCategoryRepository.GetAsync(command.CategoryId);
        if (eventCategory == null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        if (_eventCategoryRepository.Exists(x => x.CategoryName == command.CategoryName && x.CategoryId != command.CategoryId))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var slug = command.Slug.Slugify();

        eventCategory.Edit(command.CategoryName, slug);

        await _eventCategoryRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<EditEventCategory?> GetDetailsAsync(long id)
    {
        return await _eventCategoryRepository.GetDetailsAsync(id);
    }

    public async Task<List<EventCategoryViewModel>> GetEventCategoriesAsync()
    {
        return await _eventCategoryRepository.GetEventCategoriesAsync();
    }

    public async Task<List<EventCategoryViewModel>> SearchAsync(EventCategorySearchModel searchModel)
    {
        return await _eventCategoryRepository.SearchAsync(searchModel);
    }
}