using prog.DataAccess.Entity;

namespace prog.Repositories
{
    public interface IUserRepository
    {
        User WriteUser(User user);
        bool RemoveUser(Guid Id);
        bool UpdateUser(User user);
        User ReadUserById(Guid Id);
        List<User> ReadUser();
        bool checkEmailContains(string email);
    }
}