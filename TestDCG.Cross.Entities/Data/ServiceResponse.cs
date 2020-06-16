namespace TestDCG.Cross.Entities.Data
{
    public class ServiceResponse<T> where T : class, new()
    {
        public bool SuccessTransaction { get; set; }

        public int Status { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
    }
}
