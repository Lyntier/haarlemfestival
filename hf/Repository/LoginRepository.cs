using hf.Models;
using System.Linq;

namespace hf.Repository
{
    public class LoginRepository : GenericRepository<Login>
    {

        public Login GetLogin(string Username, string Password){
            return _context.Logins.FirstOrDefault(m =>
            m.Username.Equals(Username) &&
            m.Password.Equals(Password));
        }


    }
}