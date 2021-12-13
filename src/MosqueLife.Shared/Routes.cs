namespace MosqueLife.Shared;

public static class Routes
{
    public static class Account
    {
        public const string Login = "account/login";
        public const string Register = "account/register";
        public const string Update = "account/{email}";
        public const string Get = "account/{email}";
    }

    public static class Members
    {
        public const string GetMembers = "members";
        public const string GetMember = "members/{id}";
        public const string UpdateMember = "members/{id}";
        public const string DeleteMember = "members/{id}";
        public const string CreateMember = "members/{id}";
    }
}
