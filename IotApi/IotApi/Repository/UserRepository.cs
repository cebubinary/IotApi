using IotApi.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IotApi.Repository
{
    public class UserRepository: RepositoryBase
    {
        public UserRepository(MoviesDBDataContext context) : base(context)
        {
        }
        public bool Add(User user)
        {
            try
            {
                DataContext.Users.InsertOnSubmit(user);
                DataContext.SubmitChanges();
                
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
                var selected = from u in DataContext.Users
                               where u.Id == user.Id
                               select u;
                if (selected.FirstOrDefault() != null)
                {
                    DataContext.Users.DeleteOnSubmit(selected.FirstOrDefault());
                    DataContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}