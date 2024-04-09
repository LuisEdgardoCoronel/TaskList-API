using TaskList_API.Model;

namespace TaskList_API.Service
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetUsers();
        Task SaveUser(UserModel user);
        Task UpdateUser(Guid id, UserModel user);
        Task DeleteUser(Guid id);
    }
}
