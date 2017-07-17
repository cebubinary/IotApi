using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedContracts.SharedObjects
{
    public class Account: Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
