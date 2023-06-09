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

    public async Task<DepartmentQueryModel> GetDepartmentAsync(string slug)
    {
        var department = await _eventiContext.Departments
            .Include(x => x.Events)
            .Select(x => new DepartmentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                NationalCode = x.NationalCode,
                PostalCode = x.PostalCode,
                Description = x.Description,
                Logo = x.Logo,
                LogoTitle = x.LogoTitle,
                LogoAlt = x.LogoAlt,
                Slug = x.Slug,
            }).FirstOrDefaultAsync(x => x.Slug == slug) ?? new DepartmentQueryModel();

        department.Events = await _eventiContext.Events.Include(x=>x.Department).Where(x => x.DepartmentId == department.Id).Select(x => new EventQueryModel
        {
            Id = x.Id,
            Name = x.Name,
            Slug = x.Slug,
            ImageCover = x.ImageCover,
            ImageCoverAlt = x.ImageCoverAlt,
            ImageCoverTitle = x.ImageCoverTitle,
            SubcategoryId = x.SubcategoryId,
            SubcategorySlug = x.Subcategory.Slug,
            Subcategory = x.Subcategory.SubcategoryName,
            Address = x.Address,
            Description = x.Description,
            EventType = x.EventType,
            SupportNumber = x.SupportNumber,
            IsConfirmed = x.IsConfirmed
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
                PostalCode = x.PostalCode,
                Description = x.Description,
                Logo = x.Logo,
                LogoTitle = x.LogoTitle,
                LogoAlt = x.LogoAlt,
                Slug = x.Slug,
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
                PostalCode = x.PostalCode,
                Description = x.Description,
                Logo = x.Logo,
                LogoTitle = x.LogoTitle,
                LogoAlt = x.LogoAlt,
                Slug = x.Slug,
            }).OrderByDescending(x => x.Id).ToListAsync();
    }
}