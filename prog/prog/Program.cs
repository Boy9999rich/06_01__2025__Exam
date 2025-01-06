using prog.Services;
using prog.Services.Dto;
using System.Text.Json;

namespace prog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();

            UserCreateDto dto1 = new UserCreateDto()
            {
                FirstName = "Boyka",
                LastName = "yuriy",
                Age = 25,
                Email = "rich@gmail.com",
                Password = "1999",
            };

            UserCreateDto dto2 = new UserCreateDto()
            {
                FirstName = "rich",
                LastName = "boyev",
                Age = 15,
                Email = "life@gmail.com",
                Password = "rich2000",
            };

            userService.AddUser(dto1);
            userService.AddUser(dto2);

        }
    }
}
