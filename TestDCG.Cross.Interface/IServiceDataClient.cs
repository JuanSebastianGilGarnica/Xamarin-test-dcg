namespace TestDCG.Cross.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TestDCG.Cross.Entities.Data;

    public interface IServiceDataClient
    {
        Task<IList<DepartmetData>> GetDepartametsData();
    }
}
