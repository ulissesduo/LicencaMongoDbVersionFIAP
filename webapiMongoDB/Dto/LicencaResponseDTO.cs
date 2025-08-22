using webapiMongoDB.Model;

namespace webapiMongoDB.Dto
{
    public class LicencaResponseDTO
    {
        public string Id { get; set; }
        public string IdEpresa { get; set; }
        public int IdTipoLicenca { get; set; }
        public DateOnly Data_emissao { get; set; }
        public DateOnly Data_validade { get; set; }
        public StatusLicenca Status { get; set; }
    }
}
