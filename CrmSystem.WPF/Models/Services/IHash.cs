using System.Security.Cryptography;
using System.Text;

namespace CrmSystem.WPF.Models.Services
{
    public interface IHash
    {
        string CreateHash(string value);
    }

    public class Sha256Hash:IHash
    {
        public string CreateHash(string value)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder builder = new StringBuilder();


                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}