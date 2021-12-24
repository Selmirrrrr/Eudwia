namespace MosqueLife.Shared;

public static class Routes
{
    public static class Account
    {
        public const string Login = "account/login";
        public const string Register = "account/register";
        public const string Update = "account/{id}";
        public const string Get = "account/{id}";
    }

    public static class Members
    {
        public const string GetMembers = "members";
        public const string GetMember = "members/{memberId}";
        public const string UpdateMember = "members/{memberId}";
        public const string DeleteMember = "members/{memberId}";
        public const string CreateMember = "members/{memberId}";
    }
}
