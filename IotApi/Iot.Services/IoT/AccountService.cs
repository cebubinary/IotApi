using IoT.Data.Databases;
using IoT.Data.Repositories;
using System.Collections.Generic;
using Account = SharedContracts.SharedObjects.Account;
using Person = SharedContracts.SharedObjects.Person;


namespace Iot.Services.IoT
{
    public class AccountService:BaseService
    {
        PersonRepository _personRepository;
        public AccountService():base(new IoTDataContext())
        {
            _personRepository = new PersonRepository(DataContext);
        }
        public bool AddNewAccount(Account account)
        {
           return _personRepository.Resgister(account);
        }
        public bool Login(string username, string password)
        {
            return _personRepository.Login(username, password);
        }
        public Person Delete(Account account)
        {
             var result = _personRepository.Delete(account);
            return new Person { Address = result.Address, Age = (int)result.Age, FamilyName = result.FamilyName, Id = result.Id, Name = result.Name };
        }
        public Person Update(Account account)
        {
            var result = _personRepository.Upadte(account);
            return new Person { Address = result.Address, Age = (int)result.Age, FamilyName = result.FamilyName, Id = result.Id, Name = result.Name };

        }
        public List<Person> GetAll()
        {
            var result = _personRepository.GetAll();
            return result;
        }

    }
}
