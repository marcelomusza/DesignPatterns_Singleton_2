namespace DesignPatterns_Singleton_2.Models
{
    public class UserAccountList
    {
        private static UserAccountList _instance;
        private static readonly object _lock = new object();

        private List<UserAccount> _users = new List<UserAccount>();

        private UserAccountList()
        {
            _users = new List<UserAccount>();
        }

        public static UserAccountList GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if(_instance == null)
                        _instance = new UserAccountList();
                }
            }
            return _instance;
        }

        public void AddUsers(UserAccount user)
        {
            _users.Add(user);
        }

        public void RemoveUsers(UserAccount user)
        {
            _users.Remove(user);
        }

        public List<UserAccount> ListUsers()
        {
            return _users;
        }
    }
}
