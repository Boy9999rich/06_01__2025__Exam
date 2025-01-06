using prog.DataAccess.Entity;
using prog.Repositories;
using prog.Services.Dto;

namespace prog.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    public UserGetDto AddUser(UserCreateDto usercreateDto)
    {
        var checkingEmail = _userRepository.checkEmailContains(usercreateDto.Email);
        if (!usercreateDto.Email.EndsWith("@gmail.com") || checkingEmail)
        {
            return null;
        }
        var user = ConvertToUserEntity(usercreateDto);
        var userFromDb = _userRepository.WriteUser(user);
        var userDto = ConvertToDto(userFromDb);
        return userDto;
    }

    public bool DeleteUser(Guid Id)
    {
        var result = _userRepository.RemoveUser(Id);
        return result;
    }

    public List<UserGetDto> GetUsers()
    {
        var users = _userRepository.ReadUser();
        var usersGetDto = new List<UserGetDto>();
        foreach (var user in users)
        {
            usersGetDto.Add(ConvertToDto(user));
        }
        return usersGetDto;
    }

    public bool UpdateUserr(UserUpdateDto userupdateDto)
    {
        var user = ConvertToUser(userupdateDto);
        var userFromDb = _userRepository.UpdateUser(user);
        return userFromDb;
    }

    private User ConvertToUserEntity(UserCreateDto dto)
    {
        var user = new User()
        {
          Id = Guid.NewGuid(),
          FirstName = dto.FirstName,
          LastName = dto.LastName,
          Age = dto.Age,
          Email = dto.Email,
          Password = dto.Password,
        };
        return user;
    }

    private User ConvertToUser(UserUpdateDto dto)
    {
        var user = new User()
        {
            Id = dto.Id,
            Age = dto.Age,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
        };
        return user;
    }

    private UserGetDto ConvertToDto(User user)
    {
        var dto = new UserGetDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Age = user.Age,
        };
        return dto;
    }
}
