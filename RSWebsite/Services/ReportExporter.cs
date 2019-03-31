using DocumentFormat.OpenXml.Packaging;
using RSWebsite.DomainObjects;
using RSWebsite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSWebsite.Services
{
    public class ReportExporter : IReportExporter
    {
        public Task<SpreadsheetDocument> GenerateReport(RSObject rso)
        {
            throw new NotImplementedException();
        }
    }
}
