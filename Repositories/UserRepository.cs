using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Repositories.Helpers;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public void Save(User user)
        {
            if (user.ID == 0)
            {
                base.Create(user);
            }
            else
            {
                base.Update(user, item => item.ID == user.ID);
            }
        }

        public void RegisterUser(User NewUser, string password)
        {
            string salt, hash;
            PasswordManager Manager = new PasswordManager();
            hash = Manager.GeneratePasswordHash(password, out salt);

            NewUser.PasswordHash = hash;
            NewUser.PasswordSalt = salt;

            base.Create(NewUser);
        }

        public User GetUserByUsername(string username)
        {
            User user = base.DBSet.FirstOrDefault(u => u.Username == username);
            return user;
        }

        public User GetUserByNameAndPassword(string username, string password)
        {
            User user = base.DBSet.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                PasswordManager passManager = new PasswordManager();
                bool isValidPassword = passManager.IsPasswordMatch(password, user.PasswordHash, user.PasswordSalt);
                if (isValidPassword == false)
                {
                    user = null;
                }
            }
            return user;
        }
    }
}
