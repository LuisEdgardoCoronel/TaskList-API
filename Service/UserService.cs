using TaskList_API.Model;

namespace TaskList_API.Service
{
    public class UserService:IUserService
    {
        TaskContext context;
        public UserService(TaskContext context)
        {
            this.context = context;
        }



        public IEnumerable<UserModel> GetUsers()
        {
            return context.Users;
        }



        public UserModel GetOneUser(Guid id)
        {
            return context.Users.Find(id);
        }




        public async Task SaveUser(UserModel user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
        }




        public async Task UpdateUser(Guid id, UserModel user)
        {
            var userSearched = context.Users.Find(id);
            if (userSearched != null)
            {
                userSearched.UserName = user.UserName;
                userSearched.Password = user.Password;

                await context.SaveChangesAsync();
            }
        }




        public async Task DeleteUser(Guid id)
        {
            var userSearched = context.Users.Find(id);
            if (userSearched != null)
            {
                context.Remove(userSearched);
                await context.SaveChangesAsync();
            }
        }
    }
}
