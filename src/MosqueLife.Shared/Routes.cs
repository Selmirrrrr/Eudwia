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
}
