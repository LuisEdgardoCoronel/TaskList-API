using TaskList_API.Model;

namespace TaskList_API.utils
{
    public interface IGenerateJwtToken
    {
        string GenerateToken(UserModel user);
    }
}
