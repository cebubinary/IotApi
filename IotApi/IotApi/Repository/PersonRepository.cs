using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IotApi.DataContext;
using IotApi.Models;

namespace IotApi.Repository
{
    public class PersonRepository : RepositoryBase
    {
        public PersonRepository(MoviesDBDataContext context) : base(context)
        {
        }

        public bool Login(string Username, string Password)
        {
            var result = from u in DataContext.Users
                         where u.Username == Username && u.Password == Password
                         select u;
            return result.FirstOrDefault() != null;
        }
        public bool Resgister(Account user)
        {
            try
            {
                var account = Add(user);
                new UserRepository(DataContext).Add(new User {Id = account.Id, Password = user.Password, Username = user.Username });

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public DataContext.Person Add(Account user)
        {
            try
            {
                DataContext.Person p = new DataContext.Person
                {
                    Address = user.Address,
                    FamilyName = user.FamilyName,
                    Age = user.Age,
                    Name = user.Name
                };
                DataContext.Persons.InsertOnSubmit(p);
                DataContext.SubmitChanges();
                return p;
            }
            catch (Exception ex)
            {
                return null;
            }
            ;
        }

        public bool DeleteRegisteredAccount(Account user)
        {
            try
            {
                var account = Delete(user);
                new UserRepository(DataContext).Delete(new User { Id = account.Id, Password = user.Password, Username = user.Username });
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateRegisteredAccount(Account user)
        {
            try
            {
                var account = Upadte(user);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public DataContext.Person Upadte(Account user)
        {
            try
            {
                var selected = (from p in DataContext.Persons
                                where p.Name == user.Name && p.FamilyName == user.FamilyName
                                select p).FirstOrDefault();
                if (selected != null)
                {
                    selected.Name = user.Name;
                    selected.Address = user.Address;
                    selected.Age = user.Age;
                    DataContext.SubmitChanges();
                    return selected;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataContext.Person Delete(Account user)
        {
            try
            {
                var selected = (from p in DataContext.Persons
                               where p.Name == user.Name && p.FamilyName == user.FamilyName
                               select p).FirstOrDefault();
                if (selected != null)
                {
                    DataContext.Persons.DeleteOnSubmit(selected);
                    DataContext.SubmitChanges();
                    return selected;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }
    }
}