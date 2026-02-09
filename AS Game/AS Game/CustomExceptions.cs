using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_Game
{
    class CustomExceptions
    {
        public class UserAlreadyExistsException : Exception
        {
            public UserAlreadyExistsException(string username) : base("The username " + username + " is already taken")
            {

            }
        }
    }
}
