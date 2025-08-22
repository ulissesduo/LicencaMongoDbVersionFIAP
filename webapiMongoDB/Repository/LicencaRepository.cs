using LicencaMongoDB.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using webapiMongoDB.Model;

namespace webapiMongoDB.Repository
{
    public class LicencaRepository : ILicencaRepository
    {
        private readonly IMongoCollection<Licenca> _licencaCollection;

        public LicencaRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _licencaCollection = database.GetCollection<Licenca>(settings.Value.LicencaCollectionName);
        }

        public async Task<Licenca?> licencaById(string id)
        {
            return await _licencaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Licenca>> listLicencas()
        {
            return await _licencaCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Licenca?> atualizaLicenca(string id, Licenca licenca)
        {
            var result = await _licencaCollection.ReplaceOneAsync(x => x.Id == id, licenca);
            if (result.MatchedCount == 0) return null;
            return licenca;
        }

        public async Task<Licenca> criarLicenca(Licenca licenca)
        {
            await _licencaCollection.InsertOneAsync(licenca);
            return licenca;
        }

        public async Task<bool> deleteLicencencaById(string id)
        {
            var result = await _licencaCollection.DeleteOneAsync(x => x.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
