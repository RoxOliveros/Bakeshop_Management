using System.Threading;
using System.Threading.Tasks;

namespace Bakeshop_BusinessLogic.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default);
    }
}
