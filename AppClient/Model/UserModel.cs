using BaseLibrary.Entities;

namespace AppClient.Model
{
    public class UserModel
    {
        public UserModel()
        {
            user = new User();
        }

        public User  user { get; set; } = new User();
    }
}
