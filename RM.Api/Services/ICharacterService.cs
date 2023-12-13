using RM.Api.ViewModel;

namespace RM.Api.Services
{
    public interface ICharacterService
    {
        public Task<List<CharacterViewModel>> GetCharactersAsync();
    }
}
