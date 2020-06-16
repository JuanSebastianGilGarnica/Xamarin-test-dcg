namespace TestDCG.Cross.Interface
{
    using System.Threading.Tasks;
    using TestDCG.Cross.Entities.Models;

    public interface IDataConfirmBll
    {
        Task<DataConfirmModel> LoadModel();
    }
}
