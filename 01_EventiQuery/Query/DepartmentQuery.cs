using _01_EventiQuery.Contracts.Department;
using _01_EventiQuery.Contracts.Event;
using Eventi.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_EventiQuery.Query;

public class DepartmentQuery : IDepartmentQuery
{
    private readonly EventiContext _eventiContext;

    public DepartmentQuery(EventiContext eventiContext)
    {
        _eventiContext = eventiContext;
    }

    public async Task<DepartmentQueryModel> GetDepartmentAsync(long id)
    {
        var department = await _eventiContext.Departments
            .Include(x => x.Events)
            .Where(x=>x.Id == id)
            .Select(x => new DepartmentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                NationalCode = x.NationalCode,
                PostalCode = x.PostalCode,
            }).FirstOrDefaultAsync();

        department.Events = await _eventiContext.Events.Include(x=>x.Department).Where(x => x.DepartmentId == id).Select(x => new EventQueryModel
        {
            Id = x.Id,
            Name = x.Name,
            Slug = x.Slug,
            ImageCover = x.ImageCover,
            ImageCoverAlt = x.ImageCoverAlt,
            ImageCoverTitle = x.ImageCoverTitle,
            IsWebinar = x.IsWebinar,
            IsPrivate = x.IsPrivate,
            PayByCustomer = x.PayByCustomer,
            SubcategoryId = x.SubcategoryId,
            SubcategorySlug = x.Subcategory.Slug,
            Subcategory = x.Subcategory.SubcategoryName,
            EventInfo = x.EventInfo
        }).ToListAsync();

        return department;
    }

    public async Task<List<DepartmentQueryModel>> GetDepartmentsAsync(int number = 1000)
    {
        return await _eventiContext.Departments
            .Include(x => x.DepartmentAccounts)
            .Select(x => new DepartmentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                NationalCode = x.NationalCode,
                PostalCode = x.PostalCode
            })
            .OrderByDescending(x => x.Id)
            .Take(number)
            .ToListAsync();
    }

    public async Task<List<DepartmentQueryModel>> SearchAsync(string value)
    {
        return await _eventiContext.Departments
            .Include(x => x.DepartmentAccounts)
            .Where(x => x.Name.Contains(value))
            .Select(x => new DepartmentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                NationalCode = x.NationalCode,
                PostalCode = x.PostalCode
            }).OrderByDescending(x => x.Id).ToListAsync();
    }
}