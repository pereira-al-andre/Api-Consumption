using RM.Api.Abstractions.Responses; 

namespace RM.Api.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public CharacterRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CharactersResponse?> GetAllAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("rickandmortyapi");

                return await client.GetFromJsonAsync<CharactersResponse?>("character/?status=unknown&species=alien");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
