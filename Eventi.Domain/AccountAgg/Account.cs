using Eventi.Domain.EventAgg;
using Eventi.Domain.OrderAgg;
using Eventi.Domain.RoleAgg;

namespace Eventi.Domain.AccountAgg;

public class Account
{
    public long Id { get; private set; }
    public string? Fullname { get; private set; } = string.Empty;
    public string? State { get; private set; }
    public string? City { get; private set; }
    public string Mobile { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public string? ProfilePhoto { get; private set; }
    public DateTime? Birthday { get; private set; }
    public DateTime CreationDate { get; private set; }
    public bool IsDeactived { get; private set; }

    public string? NationalCode { get; private set; }
    public string? FatherName { get; private set; } = null;
    public bool Gender { get; private set; } // 1: male, 0: female
    public string? EducationalCenter { get; private set; } = null;
    public string? ScientificField { get; private set; } = null;
    public string? UniversityDegree { get; private set; } = null;
    public string? SeminaryDegree { get; private set; } = null;
    public string? Address { get; private set; } = null;
    public string? PostalCode { get; private set; } = null;


    public long RoleId { get; private set; }
    public Role Role { get; private set; }

    //public List<Event> MyEvents { get; set; } = new();
    //public List<AccountTicket> AccountTickets { get; set; } = new();
    public List<DepartmentAccount> DepartmentAccounts { get; set; } = new();
    public List<Order> Orders { get; set; } = new();

    public Account()
    {
    }

    public Account(string? fullname, string? state, string? city, string mobile, string? email,
        string? password, string? profilePhoto, DateTime? birthday, long roleId, string? nationalCode, string? fatherName,
        bool gender, string? educationalCenter, string? scientificField, string? universityDegree, string? seminaryDegree,
        string? address, string? postalCode)
    {
        Fullname = fullname;
        State = state;
        City = city;
        Mobile = mobile;
        Email = email;
        Password = password;
        ProfilePhoto = profilePhoto;
        Birthday = birthday;

        NationalCode = nationalCode;
        FatherName = fatherName;
        Gender = gender;
        EducationalCenter = educationalCenter;
        ScientificField = scientificField;
        UniversityDegree = universityDegree;
        SeminaryDegree = seminaryDegree;
        Address = address;
        PostalCode = postalCode;

        RoleId = roleId;
        if (roleId == 0)
        {
            RoleId = 2;
        }

        CreationDate = DateTime.Now;
        IsDeactived = false;
    }

    public void Edit(string? fullname, string? state, string? city, string mobile, string? email,
        string? profilePhoto, DateTime? birthday, long roleId, string? fatherName, bool gender,
        string? educationalCenter, string? scientificField, string? universityDegree, string? seminaryDegree,
        string? address, string? postalCode)
    {
        Fullname = fullname;
        State = state;
        City = city;
        Mobile = mobile;
        Email = email;
        Birthday = birthday;

        FatherName = fatherName;
        Gender = gender;
        EducationalCenter = educationalCenter;
        ScientificField = scientificField;
        UniversityDegree = universityDegree;
        SeminaryDegree = seminaryDegree;
        Address = address;
        PostalCode = postalCode;

        if (!string.IsNullOrWhiteSpace(profilePhoto))
        {
            ProfilePhoto = profilePhoto;
        }

        RoleId = roleId;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    public void Deactivate()
    {
        IsDeactived = true;
    }

    public void Activate()
    {
        IsDeactived = false;
    }
}