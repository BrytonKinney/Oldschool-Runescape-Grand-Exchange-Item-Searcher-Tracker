using RSWebsite.DomainObjects;
using RSWebsite.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RSWebsite.Services
{
    public class RunescapeService : IRunescapeService
    {
        private readonly IGrandExchangeService _geSvc;
        public RunescapeService(IGrandExchangeService geService)
        {
            _geSvc = geService;
        }

        public Task<FileStream> ExportGrandExchangeInfo(RSObject rso)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetGrandExchangeInfo(string id)
        {
            var itemPrices = _geSvc.GetItem(id);
            var itemChart = _geSvc.GetItemChart(id);
            return $"[{await itemPrices}, {await itemChart}]";
        }
    }
}
