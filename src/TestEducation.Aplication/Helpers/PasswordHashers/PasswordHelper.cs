    using System.Security.Cryptography;
    using System.Text;

    public class PasswordHelper
    {

        public string Encrypt(string password, string salt)
        {
            using var algorithm = new Rfc2898DeriveBytes(
            password: password,
            salt: Encoding.UTF8.GetBytes(salt),
            iterations: 3,
            hashAlgorithm: HashAlgorithmName.SHA256);

            return Convert.ToBase64String(algorithm.GetBytes(32));
        }

        public bool Verify(string password, string salt, string hash)
        {
            var newHash = Encrypt(password, salt);
            return newHash == hash;
        }

    }

