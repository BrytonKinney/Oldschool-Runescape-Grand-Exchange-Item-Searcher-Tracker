using RSWebsite.DomainObjects;
using System.IO;
using System.Threading.Tasks;

namespace RSWebsite.Interfaces
{
    public interface IRunescapeService
    {
        Task<string> GetGrandExchangeInfo(string id);
        Task<FileStream> ExportGrandExchangeInfo(RSObject rso);
    }
}
