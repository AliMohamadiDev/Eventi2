﻿using _0_Framework.Application;
using Eventi.Application.Contract.Event;
using Eventi.Application.Contract.Ticket;
using Eventi.Domain.AccountAgg;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class EventApplication : IEventApplication
{
    private readonly IPresenterRepository _presenterRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITicketApplication _ticketApplication;
    private readonly IEventRepository _eventRepository;
    private readonly IFileUploader _fileUploader;

    public EventApplication(IEventRepository eventRepository, IFileUploader fileUploader, IPresenterRepository presenterRepository, ITicketApplication ticketApplication, IAccountRepository accountRepository)
    {
        _presenterRepository = presenterRepository;
        _ticketApplication = ticketApplication;
        _accountRepository = accountRepository;
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

        Event.Edit(command.Name, image, command.Name, command.Name,
            command.Tags, slug, command.SubcategoryId, command.DepartmentId, command.EventType,
            command.Address, command.SupportNumber, command.Description, command.StartTime.ToGeorgianDateTime(),
            command.EndTime.ToGeorgianDateTime());

        var presenters = new List<Presenter>();
        foreach (var presenterId in command.PresenterIdList)
        {
            presenters.Add(_presenterRepository.GetPresenter(presenterId));
        }

        var accounts = new List<Account>();
        foreach (var accountId in command.AccountIdList)
        {
            accounts.Add(await _accountRepository.GetByIdAsync(accountId));
        }

        await _eventRepository.EditEventWithPresentersAsync(Event, presenters, accounts);

        await _eventRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreateEvent command)
    {
        var operation = new OperationResult();

        var slug = command.Name.Slugify() + Tools.GenerateRandomString(5);
        var path = $"Events/{command.Name}";
        var image = _fileUploader.Upload(command.ImageCover!, path);

        var Event = new Event(command.Name, image, command.Name, command.Name,
            command.Tags, slug, command.SubcategoryId, command.DepartmentId, command.EventType,
            command.Address, command.SupportNumber, command.Description, command.StartTime.ToGeorgianDateTime(),
            command.EndTime.ToGeorgianDateTime());

        var presenters = new List<Presenter>();
        foreach (var presenterId in command.PresenterIdList)
        {
            presenters.Add(_presenterRepository.GetPresenter(presenterId));
        }

        var accounts = new List<Account>();
        foreach (var accountId in command.AccountIdList)
        {
            accounts.Add(await _accountRepository.GetByIdAsync(accountId));
        }

        await _eventRepository.CreateEventWithPresentersAsync(Event, presenters, accounts);
        await _eventRepository.SaveChangesAsync();

        var eventId = Event.Id;
        if (command.Tickets.Count > 0)
        {
            foreach (var ticket in command.Tickets)
            {
                ticket.EventId = eventId;
                await _ticketApplication.CreateTicketAsync(ticket);
            }
        }

        return operation.Succeeded();
    }

    public async Task<List<EventViewModel>> SearchAsync(EventSearchModel searchModel, string userRole, long userId)
    {
        return await _eventRepository.SearchAsync(searchModel, userRole, userId);
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