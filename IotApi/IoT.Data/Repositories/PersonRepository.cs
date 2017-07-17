using IoT.Data.Databases;
using SharedContracts.SharedObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IoT.Data.Repositories
{
    public class PersonRepository : RepositoryBase
    {
        public PersonRepository(IoTDataContext context) : base(context)
        {
        }

        public bool Login(string Username, string Password)
        {
            var result = from u in IoTDContext.Users
                         where u.Username == Username && u.Password == Password
                         select u;
            return result.FirstOrDefault() != null;
        }
        public bool Resgister(Account user)
        {
            try
            {
                var account = Add(user);
                new UserRepository(IoTDContext).Add(new User { Id = account.Id, Password = user.Password, Username = user.Username });

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public Databases.Person Add(Account user)
        {
            try
            {
                Databases.Person p = new Databases.Person
                {
                    Address = user.Address,
                    FamilyName = user.FamilyName,
                    Age = user.Age,
                    Name = user.Name
                };

                IoTDContext.Persons.InsertOnSubmit(p);
                IoTDContext.SubmitChanges();
                return p;              
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public bool DeleteRegisteredAccount(Account user)
        {
            try
            {
                var account = Delete(user);
                new UserRepository(IoTDContext).Delete(new User { Id = account.Id, Password = user.Password, Username = user.Username });
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

        public Databases.Person Upadte(Account user)
        {
            try
            {
                var selected = (from p in IoTDContext.Persons
                                where p.Name == user.Name && p.FamilyName == user.FamilyName
                                select p).FirstOrDefault();
                if (selected != null)
                {
                    selected.Name = user.Name;
                    selected.Address = user.Address;
                    selected.Age = user.Age;
                    IoTDContext.SubmitChanges();
                    return selected;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Databases.Person Delete(Account user)
        {
            try
            {
                var selected = (from p in IoTDContext.Persons
                                where p.Name == user.Name && p.FamilyName == user.FamilyName
                                select p).FirstOrDefault();
                if (selected != null)
                {
                    IoTDContext.Persons.DeleteOnSubmit(selected);
                    IoTDContext.SubmitChanges();
                    return selected;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SharedContracts.SharedObjects.Person> GetAll()
        {
            var result = IoTDContext.Persons;
            var list = result.Select(x => new SharedContracts.SharedObjects.Person { Address = x.Address, Age = (int)x.Age, FamilyName = x.FamilyName, Id = x.Id, Name = x.Name }).ToList();         

            return list;
        }
    }
}