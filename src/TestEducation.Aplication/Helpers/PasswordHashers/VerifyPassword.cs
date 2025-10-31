using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEducation.Aplication.Helpers.PasswordHashers
{
    public class VerifyPassword
    {
        private readonly PasswordHelper _passwordHelper;

        public VerifyPassword(PasswordHelper passwordHelper)
        {
            _passwordHelper = passwordHelper;
        }

        public bool Verify(string inputpassword, string salt, string hash)
        {
            var newHash = _passwordHelper.Encrypt(inputpassword, salt);

            return newHash == hash;
        }
    }
}
