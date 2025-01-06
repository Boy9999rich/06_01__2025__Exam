using prog.Services.Dto;

namespace prog.Services
{
    public interface IUserService
    {
        UserGetDto AddUser(UserCreateDto usercreateDto);
        bool DeleteUser(Guid Id);
        bool UpdateUserr(UserUpdateDto userupdateDto);
        List<UserGetDto> GetUsers();
       
    }
}