using _0_Framework.Application;
using Eventi.Application.Contract.Account;
using Eventi.Domain.AccountAgg;
using Eventi.Domain.RoleAgg;

namespace Eventi.Application;

public class AccountApplication : IAccountApplication
{
    private readonly IAuthHelper _authHelper;
    private readonly IFileUploader _fileUploader;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IAccountRepository _accountRepository;

    public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader,
        IPasswordHasher passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository)
    {
        _authHelper = authHelper;
        _fileUploader = fileUploader;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _accountRepository = accountRepository;
    }

    public async Task<OperationResult> RegisterAsync(RegisterAccount command)
    {
        var operation = new OperationResult();

        if (_accountRepository.Exists(x => x.Email == command.Email || x.Mobile == command.Mobile))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var password = _passwordHasher.Hash(command.Password);
        var path = $"profilePhotos";
        //var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
        var picturePath = $"{path}\\DefaultProfilePicture.svg";

        long roleId = command.RoleId == 0 ? 2 : command.RoleId;

        var account = new Account(command.Fullname, null, null, command.Mobile, command.Email?.ToLower(),
            password, picturePath, null, roleId);
        await _accountRepository.CreateAsync(account);
        await _accountRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> EditAsync(EditAccount command)
    {
        var operation = new OperationResult();
        var account = await _accountRepository.GetAsync(command.Id);

        if (account == null)
            operation.Failed(ApplicationMessages.RecordNotFound);

        if (_accountRepository.Exists(x =>
                (x.Email == command.Email || x.Mobile == command.Mobile) && x.Id != command.Id))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

        var path = $"profilePhotos";
        var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
        //var picturePath = $"{path}\\DefaultProfilePicture.jpg";
        account?.Edit(command.Fullname, null, null, command.Mobile, command.Email?.ToLower(), picturePath, null,
            command.RoleId);
        await _accountRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<OperationResult> ChangePasswordAsync(ChangePassword command)
    {
        var operation = new OperationResult();
        var account = await _accountRepository.GetAsync(command.Id);
        if (account == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (command.Password != command.RePassword)
            return operation.Failed(ApplicationMessages.PasswordsNotMatch);

        var password = _passwordHasher.Hash(command.Password);
        account.ChangePassword(password);
        await _accountRepository.SaveChangesAsync();
        return operation.Succeeded();
    }

    public async Task<List<AccountViewModel>> GetAccountsAsync()
    {
        return await _accountRepository.GetAccountsAsync();
    }

    public async Task<OperationResult> LoginAsync(Login command)
    {
        var operation = new OperationResult();
        var account = await _accountRepository.GetByAsync(command.Email);

        if (account == null)
            return operation.Failed(ApplicationMessages.WrongUserPass);

        var result = _passwordHasher.Check(account.Password, command.Password);

        if (!result.Verified)
            return operation.Failed(ApplicationMessages.WrongUserPass);

        var permissions = _roleRepository.GetById(account.RoleId)!
            .Permissions
            .Select(x => x.Code)
            .ToList();

        var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname,
            account.Email, permissions, account.ProfilePhoto);

        _authHelper.Signin(authViewModel);

        return operation.Succeeded();
    }

    public async Task<EditAccount?> GetDetailsAsync(long id)
    {
        return await _accountRepository.GetDetailsAsync(id);
    }

    public async Task<List<AccountViewModel>> SearchAsync(AccountSearchModel searchModel)
    {
        return await _accountRepository.SearchAsync(searchModel);
    }

    public void Deactivate(long id)
    {
        _accountRepository.Deactivate(id);
    }

    public void Activate(long id)
    {
        _accountRepository.Activate(id);
    }

    public void Logout()
    {
        _authHelper.SignOut();
    }
}