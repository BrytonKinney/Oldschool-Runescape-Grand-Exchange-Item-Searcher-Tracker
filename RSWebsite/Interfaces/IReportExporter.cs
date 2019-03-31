using DocumentFormat.OpenXml.Packaging;
using RSWebsite.DomainObjects;
using System.Threading.Tasks;

namespace RSWebsite.Interfaces
{
    public interface IReportExporter
    {
        Task<SpreadsheetDocument> GenerateReport(RSObject rso);
    }
}
