using Eventi.Application.Contract.Account;
using Eventi.Domain.AccountAgg;
using Eventi.Domain.EventAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Accounts;

public class AddDepartmentModel : PageModel
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IAccountApplication _accountApplication;

    public AddDepartmentModel(IDepartmentRepository departmentRepository, IAccountRepository accountRepository, IAccountApplication accountApplication)
    {
        _departmentRepository = departmentRepository;
        _accountRepository = accountRepository;
        _accountApplication = accountApplication;
    }

    [BindProperty]
    public Account Account { get; set; }

    [BindProperty]
    public long[] SelectedDepartmentIds { get; set; }

    public SelectList DepartmentListItems { get; set; }


    public async Task<IActionResult> OnGetAsync(long id)
    {
        Account = await _accountRepository.GetByIdAsync(id);

        if (Account == null)
        {
            return NotFound();
        }

        var departments = await _departmentRepository.GetAccountSidesAsync();
        DepartmentListItems = new SelectList(departments, "Id", "Name");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(long id)
    {
        Account = await _accountRepository.GetByIdAsync(id);

        _accountRepository.ClearDepartmentsOfAccount(id);

        Account.DepartmentAccounts = new List<DepartmentAccount>();

        foreach (var departmentId in SelectedDepartmentIds)
        {
            var department = _departmentRepository.GetDepartment(departmentId);

            if (department != null)
            {
                Account.DepartmentAccounts.Add(new DepartmentAccount { Department = department });
            }
        }

        _accountRepository.UpdateAccount(Account);

        return RedirectToPage("./Index");
    }
}