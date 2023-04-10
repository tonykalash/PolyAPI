using Microsoft.EntityFrameworkCore;
using PolyAPI.Commons.DTO;
using PolyAPI.Interface.User;
using PolyAPI.Models;

namespace PolyAPI.Commons.User
{
    public class UserClass : IUser
    {
        private readonly polyclinic_kalashnikovContext _context;
        public UserClass(polyclinic_kalashnikovContext context)
        {
            _context = context;
        }

        public List<UserDTO> GetUserById(int id)
        {
            List<UserDTO> data = _context.Users
                .Select(
                    x => new UserDTO
                    {
                        UserId = x.UserId,
                        UserName = x.UserName,
                        UserLogin = x.UserLogin,
                    }
                )

                .Where(u => u.UserId == id).ToList();

            if (data != null)
            {
                return data;
            }
            else
            {
                return new List<UserDTO>() {
                            new UserDTO{
                                UserId = 0,
                                UserName = "Данные отсутствуют",
                                UserLogin = "Данные отсутствуют"
                            }
                };
            }
        }
    }
}