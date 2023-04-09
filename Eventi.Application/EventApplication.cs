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
        var image = _fileUploader.Upload(command.ImageCover, path);

        Event.Edit(command.Name, image, command.ImageCoverTitle, command.ImageCoverAlt,
            command.Tags, command.IsWebinar, command.IsPrivate, command.PayByCustomer, slug,
            command.SubcategoryId, command.DepartmentId);

        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreateEvent command)
    {
        var operation = new OperationResult();

        var slug = command.Name.Slugify();
        var path = $"Events/{command.Name}";
        var image = _fileUploader.Upload(command.ImageCover, path);

        var Event = new Event(command.Name, image, command.ImageCoverTitle, command.ImageCoverAlt,
            command.Tags, command.IsWebinar, command.IsPrivate, command.PayByCustomer, slug,
            command.SubcategoryId, command.DepartmentId);

        await _eventRepository.CreateAsync(Event);
        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel)
    {
        return await _eventRepository.SearchAsync(searchModel);
    }

    public void Remove(long id)
    {
        _eventRepository.Remove(id);
    }

    public void Restore(long id)
    {
        _eventRepository.Restore(id);
    }
}