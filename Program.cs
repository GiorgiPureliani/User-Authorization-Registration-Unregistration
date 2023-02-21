namespace Project9
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(UserManager.Login("Gio1978", "123")); //false
            User user1 = new User();
            user1.Username = "Gio1978";
            user1.Password = "123";
            Console.WriteLine(UserManager.Register(user1)); //0
            Console.WriteLine(UserManager.Register(user1)); //-2

            User user2 = new User() { Username = "Mzia9897", Password = "9897" };
            Console.WriteLine(UserManager.Register(user2)); //0
            Console.WriteLine(UserManager.Login("Gio1978", "123")); //true
            Console.WriteLine(UserManager.Login("Gio1978", "111")); //false
            Console.WriteLine(UserManager.UnRegister("Giorgi1978")); //false
            Console.WriteLine(UserManager.UnRegister("Gio1978")); //true
            Console.WriteLine(UserManager.Login("Gio1978", "123")); //false
        }
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    static class UserManager
    {
        static private User[] _users = new User[10];
        static public int Register(User user)
        {
            if (!IsUserValid(user))
            {
                return -1;
            }

            if (UserExists(user.Username))
            {
                return -2;
            }

            if (IsDatabaseFull())
            {
                return -3;
            }

            int emptyIndex = GetEmptyIndex();
            _users[emptyIndex] = user;

            return 0;
        }
        static public bool Login(string username, string password)
        {
            User? user = GetUser(username);

            if (user != null && user.Password == password)
            {
                return true;
            }

            return false;
        }
        static public bool UnRegister(string username)
        {
            int index = GetIndex(username);

            if (index != -1)
            {
                _users[index] = null;
                return true;
            }

            return false;
        }
        static private bool IsUserValid(User user)
        {
            if (user != null &&
                  !string.IsNullOrEmpty(user.Username) && user.Username.Length >= 8 &&
                  !string.IsNullOrEmpty(user.Password))
            {
                return true;
            }

            return false;
        }
        static private User? GetUser(string username)
        {
            int index = GetIndex(username);

            if (index != -1)
            {
                return _users[index];
            }

            return null;
        }
        static private int GetIndex(string username)
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] != null && _users[i].Username == username)
                {
                    return i;
                }
            }

            return -1;
        }
        static private bool UserExists(string username)
        {
            //int index = GetIndex(username);
            //if (index != -1)
            //{
            //    return true;
            //}
            //return false;

            return GetIndex(username) != -1;
        }
        static private int GetEmptyIndex()
        {
            for (int i = 0; i < _users.Length; i++)
            {
                if (_users[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }
        static private bool IsDatabaseFull()
        {
            //int index = GetEmptyIndex();
            //if (index == -1)
            //{
            //    return true;
            //}
            //return false;

            return GetEmptyIndex() == -1;
        }
    }
}