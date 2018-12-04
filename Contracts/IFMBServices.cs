using FMBPublic.Model;
using System.Collections.Generic;

namespace FMB.Services
{
    public interface IFMBServices
    {
        ConnectionSetting Cs { get; set; }
        List<DashboardResult> GetDashboardResults();
    }
}