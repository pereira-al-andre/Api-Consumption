using RM.Api.Abstractions.Responses; 

namespace RM.Api.Repositories
{
    public interface ICharacterRepository
    {
        public Task<CharactersResponse?> GetAllAsync();
    }
}
