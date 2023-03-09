using _0_Framework.Application;
using Eventi.Application.Contract.EventInfo;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class EventInfoApplication : IEventInfoApplication
{
    private readonly IEventInfoRepository _eventInfoRepository;

    public EventInfoApplication(IEventInfoRepository eventInfoRepository)
    {
        _eventInfoRepository = eventInfoRepository;
    }

    public async Task<EditEventInfo?> GetDetailsAsync(long id)
    {
        return await _eventInfoRepository.GetDetailsAsync(id);
    }

    public async Task<List<EventInfoViewModel>> GetEventInfosAsync()
    {
        return await _eventInfoRepository.GetEventInfosAsync();
    }

    public async Task<OperationResult> EditEventInfoAsync(EditEventInfo command)
    {
        var operation = new OperationResult();
        var eventInfo = _eventInfoRepository.GetEventInfo(command.Id);

        if (_eventInfoRepository.Exists(x => x.EventId == command.EventId && x.Id != command.Id))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        string? state = null;
        string? city = null;
        string? address = null;

        if (!command.IsWebinar)
        {
            state = command.State;
            city = command.City;
            address = command.Address;
        }


        float totalHours = 0;
        int roomCapacity = 0;
        if (command.IsWebinar && !command.IsPersonalSystem)
        {
            totalHours = command.TotalHours;
            roomCapacity = command.RoomCapacity;
        }

        string? hostingService = null;
        string? loginLink = null;
        string? description = null;
        if (command.IsWebinar && command.IsPersonalSystem)
        {
            hostingService = command.HostingService;
            loginLink = command.LoginLink;
            description = command.Description;
        }

        eventInfo.Edit(command.IsWebinar, command.IsPersonalSystem, command.Length, state,
            city, address, hostingService, loginLink, description,
            command.StartTime.ToGeorgianDateTime(), command.EndTime.ToGeorgianDateTime(), command.EventId,
            totalHours, roomCapacity);

        await _eventInfoRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateEventInfo(CreateEventInfo command)
    {
        var operation = new OperationResult();

        if (_eventInfoRepository.Exists(x => x.EventId == command.EventId))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        string? state = null;
        string? city = null;
        string? address = null;

        if (!command.IsWebinar)
        {
            state = command.State;
            city = command.City;
            address = command.Address;
        }


        float totalHours = 0;
        int roomCapacity = 0;
        if (command.IsWebinar && !command.IsPersonalSystem)
        {
            totalHours = command.TotalHours;
            roomCapacity = command.RoomCapacity;
        }

        string? hostingService = null;
        string? loginLink = null;
        string? description = null;
        if (command.IsWebinar && command.IsPersonalSystem)
        {
            hostingService = command.HostingService;
            loginLink = command.LoginLink;
            description = command.Description;
        }

        var eventInfo = new EventInfo(command.IsWebinar, command.IsPersonalSystem, command.Length, state,
            city, address, hostingService, loginLink, description,
            command.StartTime.ToGeorgianDateTime(), command.EndTime.ToGeorgianDateTime(), command.EventId,
            totalHours, roomCapacity);

        await _eventInfoRepository.CreateAsync(eventInfo);
        await _eventInfoRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<EventInfoViewModel>> SearchAsync(EventInfoSearchModel searchModel)
    {
        return await _eventInfoRepository.SearchAsync(searchModel);
    }
}