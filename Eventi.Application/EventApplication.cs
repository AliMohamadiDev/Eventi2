using _0_Framework.Application;
using Eventi.Application.Contract.Event;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class EventApplication : IEventApplication
{
    private readonly IEventRepository _eventRepository;

    public EventApplication(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<EditEvent?> GetDetailsAsync(long id)
    {
        return await _eventRepository.GetDetailsAsync(id);
    }

    public async Task<List<EventViewModel>> GetEventsAsync()
    {
        return await _eventRepository.GetEventsAsync();
    }

    public async Task<OperationResult> EditAsync(EditEvent command)
    {
        var operation = new OperationResult();
        var Event = _eventRepository.GetEvent(command.Id);

        Event.Edit(command.Name, command.ImageCover, command.ImageCoverTitle, command.ImageCoverAlt,
            command.Tags, command.IsWebinar, command.IsPrivate, command.PayByCustomer, command.Link, command.Slug,
            command.SubcategoryId, command.AccountSideId);

        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreateEvent command)
    {
        var operation = new OperationResult();

        var Event = new Event(command.Name, command.ImageCover, command.ImageCoverTitle, command.ImageCoverAlt,
            command.Tags, command.IsWebinar, command.IsPrivate, command.PayByCustomer, command.Link, command.Slug,
            command.SubcategoryId, command.AccountSideId);

        await _eventRepository.CreateAsync(Event);
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel)
    {
        return await _eventRepository.SearchAsync(searchModel);
    }
}