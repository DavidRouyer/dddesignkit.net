using System.Threading;
using System.Threading.Tasks;

namespace Dddesignkit.Internal
{
    public interface IHttpClient
    {
        Task<IResponse> Send(IRequest request, CancellationToken cancellationToken);
    }
}
