using IoT.Data.Databases;
using System;
using System.Linq;

namespace IoT.Data.Repositories
{
    public class UserRepository: RepositoryBase
    {
        public UserRepository(IoTDataContext context) : base(context)
        {
        }
        public bool Add(User user)
        {
            try
            {
                IoTDContext.Users.InsertOnSubmit(user);
                IoTDContext.SubmitChanges();
                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Delete(User user)
        {
            try
            {
                var selected = from u in IoTDContext.Users
                               where u.Id == user.Id
                               select u;
                if (selected.FirstOrDefault() != null)
                {
                    IoTDContext.Users.DeleteOnSubmit(selected.FirstOrDefault());
                    IoTDContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }   
        }
    }
}