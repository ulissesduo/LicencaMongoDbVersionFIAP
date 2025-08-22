using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webapiMongoDB.Model
{
    public class Licenca
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        //[BsonElement("IdEmpresa")]
        //public int IdEmpresa { get; set; }

        // ALTERADO: antes era int, agora string para permitir flexibilidade
        // Pode receber manualmente um valor ou um ObjectId aleatório
        [BsonElement("IdEmpresa")] // ⬅️ garante que o MongoDB leia/grave corretamente
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEmpresa { get; set; }


        [BsonElement("IdTipoLicenca")]
        public int IdTipoLicenca { get; set; }

        [BsonElement("Data_emissao")]
        public DateTime Data_emissao { get; set; }   // Mongo doesn’t have DateOnly, use DateTime

        [BsonElement("Data_validade")]
        public DateTime Data_validade { get; set; }

        [BsonElement("Status")]
        [BsonRepresentation(BsonType.String)]
        public StatusLicenca Status { get; set; }
    }
}
