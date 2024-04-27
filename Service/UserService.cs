using TaskList_API.Model;
using TaskList_API.utils;

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
            string NewPassword = PasswordEncryptor.EncryptPassword(user.Password);
            user.Password = NewPassword;
            context.Add(user);
            await context.SaveChangesAsync();
        }




        public async Task UpdateUser(Guid id, UserModel user)
        {
            var userSearched = context.Users.Find(id);
            if (userSearched != null)
            {
                userSearched.UserName = user.UserName;
                userSearched.Password = PasswordEncryptor.EncryptPassword(user.Password);

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




        public Boolean Authenticate(UserModel user)
        {
            var userSearched = context.Users.Find(user.UserId);

            //encriptamos la clave ingresada para comparar
            string password = PasswordEncryptor.EncryptPassword(user.Password);

            //comparamos la clave ingresada con la clave que corresponde al usuario
            if(user.UserName == userSearched.UserName) return PasswordEncryptor.VerifyPassword(userSearched.Password, password);
            else return false;
        }
    }
}
