using PolyAPI.Commons.DTO;
using PolyAPI.Models;

namespace PolyAPI.Interface.User
{
    public interface IUser
    {
        public List<UserDTO> GetUserById(int id);
    }
}
