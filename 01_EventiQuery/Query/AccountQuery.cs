using _01_EventiQuery.Contracts.Account;
using _01_EventiQuery.Contracts.Event;
using Eventi.Application.Contract.Department;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class AccountQuery : IAccountQuery
{
    private readonly EventiContext _context;

    public AccountQuery(EventiContext context)
    {
        _context = context;
    }

    public async Task<AccountQueryModel?> GetAccountDetailsAsync(long id)
    {
        var account = await _context.Accounts
            //.Include(x => x.AccountTickets)
            .Include(x=>x.DepartmentAccounts)
            .Select(x => new AccountQueryModel
            {
                Id = x.Id,
                ProfilePhoto = x.ProfilePhoto,
                Fullname = x.Fullname,
                Email = x.Email,
                Birthday = x.Birthday,
                State = x.State,
                City = x.City,
                Mobile = x.Mobile,
                Role = x.Role,
                RoleId = x.RoleId,
                CreationDate = x.CreationDate,
                IsDeactived = x.IsDeactived,
            }).FirstOrDefaultAsync(x => x.Id == id);

        account.Departments = _context.DepartmentAccounts.Include(x => x.Department).Where(x=>x.AccountId == id).Select(x=>new DepartmentViewModel
        {
            Id = x.Department.Id,
            Address = x.Department.Address,
            Name = x.Department.Name,
            NationalCode = x.Department.NationalCode,
            PostalCode = x.Department.PostalCode
        }).ToList();

        var orders = _context.Orders.Include(x=>x.Ticket).Where(x => x.AccountId == id).ToList();
        account.Orders = orders;

        account.Tickets = orders.Select(x => new TicketQueryModel
        {
            Id = x.Ticket.Id,
            Title = x.Ticket.Title,
            Price = x.Ticket.Price,
            DiscountRate = x.Ticket.DiscountRate,
            EventId = x.Ticket.EventId,
            Description = x.Ticket.Description,
            Number = x.Ticket.Number,
            StartTime = x.Ticket.StartTime,
            EndTime = x.Ticket.EndTime,
            EventSlug = _context.Events.Where(z=>z.Id == x.Ticket.EventId).Select(y=>y.Slug).FirstOrDefault()
        }).ToList();

        return account;
    }
}