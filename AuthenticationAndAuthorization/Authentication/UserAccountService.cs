namespace AuthenticationAndAuthorization.Authentication
{
    public class UserAccountService
    {
        private List<UserAccountModel> _users;

        public UserAccountService()
        {
            _users = new List<UserAccountModel>()
            {
                new UserAccountModel{UserName="admin",Password="admin",Role="Administrator"},
                new UserAccountModel{UserName="user",Password="user", Role="User"}
            };

        }

        public UserAccountModel? GetAccountByUsername(string username)
        {
            return _users.FirstOrDefault(x=>x.UserName==username);
        }
    }
}
