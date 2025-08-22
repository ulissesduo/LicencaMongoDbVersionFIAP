using webapiMongoDB.Model;
using webapiMongoDB.Repository;

namespace webapiMongoDB.Service
{
    public class LicencaService : ILicencaService
    {
        private readonly ILicencaRepository _repository;

        public LicencaService(ILicencaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Licenca> CreateLicencaAsync(Licenca licenca) =>
            await _repository.criarLicenca(licenca);

        public async Task<bool> DeleteLicencaAsync(string id) =>
            await _repository.deleteLicencencaById(id);

        public async Task<List<Licenca>> GetAllLicencasAsync() =>
            await _repository.listLicencas();

        public async Task<Licenca?> GetLicencaByIdAsync(string id) =>
            await _repository.licencaById(id);

        public async Task<Licenca?> UpdateLicencaAsync(string id, Licenca licenca) =>
            await _repository.atualizaLicenca(id, licenca);
    }
}
