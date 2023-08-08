namespace _0_Framework.Infrastructure;

public static class Roles
{
    public const string Administration = "1";
    public const string SystemUser = "2";
    public const string BlogAdmin = "3";
    public const string Presenter = "4";

    public static string GetRoleBy(long id)
    {
        return id switch
        {
            1 => "مدیر سیستم",
            2 => "کاربر سیستم",
            3 => "مدیر بلاگ",
            4 => "برگزارکننده",
            _ => ""
        };
    }
}