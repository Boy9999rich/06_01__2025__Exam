using prog.DataAccess.Entity;
using System.Text.Json;

namespace prog.Repositories;

public class UserRepository : IUserRepository
{
    private string path;
    private List<User> _users;

    public UserRepository()
    {
        path = "../../../DataAccess/Data/Users.json";
        _users = new List<User>();

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "[]");
        }
        else
        {
            _users = ReadUser();
        }
    }

    private void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(_users);
        File.WriteAllText(path, jsonData);
    }
    public List<User> ReadUser()
    {
        var usersjson = File.ReadAllText(path);
        var users = JsonSerializer.Deserialize<List<User>>(usersjson);
        return users;
    }

    public User ReadUserById(Guid Id)
    {
        foreach (var user in _users)
        {
            if (user.Id == Id)
            {
                return user;
            }
        }
        return null;
    }

    public bool RemoveUser(Guid Id)
    {
        var removingUser = ReadUserById(Id);
        if (removingUser is null)
        {
            return false;
        }
        else
        {
            _users.Remove(removingUser);
            SaveData();
            return false;
        }
    }

    public bool UpdateUser(User user)
    {
        var updatingUser = ReadUserById(user.Id);
        if (updatingUser is null)
        {
            return false;
        }
        var index = _users.IndexOf(user);
        _users[index] = user;
        SaveData();
        return true;
    }

    public User WriteUser(User user)
    {
        _users.Add(user);
        SaveData();
        return user;
    }

    public bool checkEmailContains(string email)
    {
        var users = ReadUser();
        foreach (var user in users)
        {
            if (user.Email == email)
            {
                return true;
            }
        }
        return false;
    }
}
