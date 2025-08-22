using webapiMongoDB.Model;

namespace webapiMongoDB.Repository
{
    public interface ILicencaRepository
    {
        Task<Licenca?> licencaById(string id);
        Task<List<Licenca>> listLicencas();
        Task<Licenca?> atualizaLicenca(string id, Licenca licenca);
        Task<Licenca> criarLicenca(Licenca licenca);
        Task<bool> deleteLicencencaById(string id);
    }
}
