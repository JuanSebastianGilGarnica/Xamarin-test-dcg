namespace TestDCG.DataAccess.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TestDCG.Cross.Entities.Data;
    using TestDCG.Cross.Interface;
    using TestDCG.DataAccess.Service.Reference;

    public class ServiceDataClient : ServiceBase, IServiceDataClient
    {
        private const string urlDataService = "https://www.datos.gov.co/resource/xdk5-pm3f.json?%24limit=2000";

        public ServiceDataClient() : base()
        {
        }

        public async Task<IList<DepartmetData>> GetDepartametsData()
        {
            return await Get<List<DepartmetData>>(urlDataService).ConfigureAwait(false) ?? new List<DepartmetData>();
        }
    }
}
