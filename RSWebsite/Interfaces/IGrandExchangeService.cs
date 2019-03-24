using System.Threading.Tasks;

namespace RSWebsite.Interfaces
{
    public interface IGrandExchangeService
    {
        Task<string> GetItemChart(string itemId);

        Task<string> GetItem(string itemId);
    }
}
