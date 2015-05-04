using System.Threading.Tasks;

namespace Dddesignkit
{
    public interface ICredentialStore
    {
        Task<Credentials> GetCredentials();
    }
}
