namespace TestDCG.Cross.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TestDCG.Cross.Entities.Data;
    using TestDCG.Cross.Entities.Models;
    using TestDCG.Cross.Entities.Reference;
    using TestDCG.Cross.Interface;

    public class DataConfirmBll : IDataConfirmBll
    {
        readonly IServiceDataClient _serviceData;

        public DataConfirmBll(IServiceDataClient serviceData)
        {
            _serviceData = serviceData;
        }

        public async Task<DataConfirmModel> LoadModel()
        {
            try
            {
                IList<DepartmetData> data = await _serviceData.GetDepartametsData().ConfigureAwait(false);
                List<Department> dept = data.Distinct(new DeptComparer()).Select(d => new Department
                {
                    Description = d.Department,
                    Id = d.DaneCodeDept
                }).ToList();
                List<Municipalitie> mun = data.Select(d => new Municipalitie
                {
                    DepartamentId = d.DaneCodeDept,
                    Id = d.DaneCodeMun,
                    Description = d.Municipalitie
                }).ToList();
                return new DataConfirmModel(mun, dept);
            }
            catch (Exception ex)
            {
                return new DataConfirmModel(new List<Municipalitie>(), new List<Department>());
            }
        }
    }
}
