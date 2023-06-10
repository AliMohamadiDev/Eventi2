using _0_Framework.Application;
using Eventi.Application.Contract.Event;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class EventApplication : IEventApplication
{
    private readonly IEventRepository _eventRepository;
    private readonly IFileUploader _fileUploader;

    public EventApplication(IEventRepository eventRepository, IFileUploader fileUploader)
    {
        _eventRepository = eventRepository;
        _fileUploader = fileUploader;
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

        var slug = command.Name.Slugify();

        var path = $"Events/{command.Name}";
        var image = _fileUploader.Upload(command.ImageCover!, path);

        Event.Edit(command.Name, image, command.ImageCoverTitle, command.ImageCoverAlt,
            command.Tags, slug, command.SubcategoryId, command.DepartmentId, command.EventType,
            command.Address, command.SupportNumber, command.Description, command.StartTime.ToGeorgianDateTime(),
            command.EndTime.ToGeorgianDateTime());

        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreateEvent command)
    {
        var operation = new OperationResult();

        var slug = command.Name.Slugify();
        var path = $"Events/{command.Name}";
        var image = _fileUploader.Upload(command.ImageCover!, path);

        var Event = new Event(command.Name, image, command.ImageCoverTitle, command.ImageCoverAlt,
            command.Tags, slug, command.SubcategoryId, command.DepartmentId, command.EventType,
            command.Address, command.SupportNumber, command.Description, command.StartTime.ToGeorgianDateTime(),
            command.EndTime.ToGeorgianDateTime());

        await _eventRepository.CreateAsync(Event);
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel)
    {
        return await _eventRepository.SearchAsync(searchModel);
    }

    public async Task<OperationResult> RemoveAsync(long id)
    {
        var operation = new OperationResult();
        var event1 = _eventRepository.GetEvent(id);

        if (event1 == null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        event1.Remove();
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> RestoreAsync(long id)
    {
        var operation = new OperationResult();
        var event1 = _eventRepository.GetEvent(id);

        if (event1 == null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        event1.Restore();
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> ConfirmAsync(long id)
    {
        var operation = new OperationResult();
        var event1 = _eventRepository.GetEvent(id);

        if (event1 == null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        event1.Confirm();
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CancelAsync(long id)
    {
        var operation = new OperationResult();
        var event1 = _eventRepository.GetEvent(id);

        if (event1 == null)
        {
            return operation.Failed(ApplicationMessages.RecordNotFound);
        }

        event1.Cancel();
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }
}