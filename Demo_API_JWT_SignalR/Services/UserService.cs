using Demo_API_JWT_SignalR.Models;

namespace Demo_API_JWT_SignalR.Services
{
    public class UserService
    {
        public List<User> UserList { get; set; }

        public UserService()
        {
            UserList = new List<User>();
            UserList.Add(new User
            {
                Id = 1,
                Username = "Arthur",
                Password = "Cuillere",
                IsAdmin = true
            });
        }

        public void Add(User u)
        {
            UserList.Add(u);
        }

        public IEnumerable<User> GetAll()
        {
            return UserList;
        }

        public User GetById(int id)
        {
            return UserList.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
