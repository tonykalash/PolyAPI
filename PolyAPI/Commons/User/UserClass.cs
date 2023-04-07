using Microsoft.EntityFrameworkCore;
using PolyAPI.Commons.DTO;
using PolyAPI.Interface.User;
using PolyAPI.Models;

namespace PolyAPI.Commons.User
{
    public class UserClass : IUser
    {
        private readonly JiinoContext _context;
        public UserClass(JiinoContext context)
        {
            _context = context;
        }

        public List<UserDTO> GetUserById(int id)
        {
            List<UserDTO> data = _context.users
                .Select(
                    x => new UserDTO
                    {
                        UserId = x.user_id,
                        UserName = x.user_name,
                        UserLogin = x.user_login,
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