using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoonkieInterview.Common.Contracts.Providers
{
    public interface IEmailProvider
    {
        Task SendEmail(string subject, string body, List<string> recipients = null);
    }
}
