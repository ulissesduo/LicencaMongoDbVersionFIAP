using webapiMongoDB.Model;

namespace webapiMongoDB.Service
{
    public interface ILicencaService
    {

        Task<Licenca> CreateLicencaAsync(Licenca licenca);
        Task<bool> DeleteLicencaAsync(string id);
        Task<List<Licenca>> GetAllLicencasAsync();
        Task<Licenca?> GetLicencaByIdAsync(string id);
        Task<Licenca?> UpdateLicencaAsync(string id, Licenca licenca);
    }
}
