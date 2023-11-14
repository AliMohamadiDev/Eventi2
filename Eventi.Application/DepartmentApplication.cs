using _0_Framework.Application;
using Eventi.Application.Contract.Department;
using Eventi.Domain.EventAgg;

namespace Eventi.Application;

public class DepartmentApplication: IDepartmentApplication
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IFileUploader _fileUploader;

    public DepartmentApplication(IDepartmentRepository departmentRepository, IFileUploader fileUploader)
    {
        _departmentRepository = departmentRepository;
        _fileUploader = fileUploader;
    }

    public async Task<EditDepartment?> GetDetailsAsync(long id)
    {
        return await _departmentRepository.GetDetailsAsync(id);
    }

    public async Task<List<DepartmentViewModel>> GetDepartmentsAsync()
    {
        return await _departmentRepository.GetAccountSidesAsync();
    }

    public async Task<OperationResult> EditAsync(EditDepartment command)
    {
        var operation = new OperationResult();
        var department = _departmentRepository.GetDepartment(command.Id);

        if (_departmentRepository.Exists(x => x.NationalCode == command.NationalCode && x.Id != command.Id))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var logoTitle = $"لوگوی {command.Name}";
        var logoAlt = $"لوگوی {command.Name}";
        //var slug = $"{command.Name}".Slugify() + Tools.GenerateRandomString(5);

        var path = $"Departments/{command.Slug}";
        var logo = _fileUploader.Upload(command.Logo, path);

        department.Edit(command.Name, command.NationalCode, command.PostalCode, command.Address, logo, logoAlt,
            logoTitle, department.Slug, command.Description);

        await _departmentRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> CreateAsync(CreateDepartment command)
    {
        var operation = new OperationResult();
        if (_departmentRepository.Exists(x => x.NationalCode == command.NationalCode))
        {
            return operation.Failed(ApplicationMessages.DuplicatedRecord);
        }

        var logoTitle = $"لوگوی {command.Name}";
        var logoAlt = $"لوگوی {command.Name}";
        var slug = $"{command.Name}".Slugify() + Tools.GenerateRandomString(5);

        var path = $"Departments/{slug}";
        var logo = _fileUploader.Upload(command.Logo, path);

        var department = new Department(command.Name, command.NationalCode, command.PostalCode, command.Address, logo,
            logoAlt, logoTitle, slug, command.Description);

        await _departmentRepository.CreateAsync(department);
        await _departmentRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<DepartmentViewModel>> SearchAsync(DepartmentSearchModel searchModel)
    {
        return await _departmentRepository.SearchAsync(searchModel);
    }
}