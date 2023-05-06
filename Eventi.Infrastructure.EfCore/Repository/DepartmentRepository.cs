using _0_Framework.Infrastructure;
using Eventi.Application.Contract.Department;
using Eventi.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Infrastructure.EfCore.Repository;

public class DepartmentRepository : RepositoryBase<long, Department>, IDepartmentRepository
{
    private readonly EventiContext _context;

    public DepartmentRepository(EventiContext context) : base(context)
    {
        _context = context;
    }

    public async Task<EditDepartment?> GetDetailsAsync(long id)
    {
        return await _context.Departments.Select(x => new EditDepartment
        {
            Id = x.Id,
            Name = x.Name,
            NationalCode = x.NationalCode,
            PostalCode = x.PostalCode,
            Address = x.Address,
            LogoAlt = x.LogoAlt,
            LogoTitle = x.LogoTitle,
            Slug = x.Slug,
            Description = x.Description
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public Department GetDepartment(long id)
    {
        return _context.Departments.FirstOrDefault(x => x.Id == id)!;
    }

    public async Task<List<DepartmentViewModel>> SearchAsync(DepartmentSearchModel searchModel)
    {
        var query = _context.Departments.Select(x => new DepartmentViewModel
        {
            Id = x.Id,
            Name = x.Name,
            NationalCode = x.NationalCode,
            PostalCode = x.PostalCode,
            Address = x.Address,
            Logo = x.Logo,
        });

        if (searchModel.Id != 0)
        {
            query = query.Where(x => x.Id == searchModel.Id);
        }

        if (searchModel.Name != null)
        {
            query = query.Where(x => x.Name.Contains(searchModel.Name));
        }

        if (searchModel.NationalCode != 0)
        {
            query = query.Where(x => x.NationalCode == searchModel.NationalCode);
        }

        return await query.OrderByDescending(x => x.Id).ToListAsync();
    }

    public async Task<List<DepartmentViewModel>> GetAccountSidesAsync()
    {
        return await _context.Departments.Select(x => new DepartmentViewModel
        {
            Id = x.Id,
            Name = x.Name,
            NationalCode = x.NationalCode,
            PostalCode = x.PostalCode,
            Address = x.Address,
            Logo = x.Logo,
        }).ToListAsync();
    }
}