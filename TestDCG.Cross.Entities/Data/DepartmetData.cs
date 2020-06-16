namespace TestDCG.Cross.Entities.Data
{
    using Newtonsoft.Json;

    public class DepartmetData
    {
        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("c_digo_dane_del_departamento")]
        public int DaneCodeDept { get; set; }

        [JsonProperty("departamento")]
        public string Department { get; set; }

        [JsonProperty("c_digo_dane_del_municipio")]
        public int DaneCodeMun { get; set; }

        [JsonProperty("municipio")]
        public string Municipalitie { get; set; }
    }
}
