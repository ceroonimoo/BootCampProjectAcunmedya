using Entity.Entities;

namespace Core.Security
{
    public interface ITokenHelper
    {
        string CreateToken(User user);
    }
}
