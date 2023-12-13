using Microsoft.Extensions.Caching.Memory;
using RM.Api.Entities;
using RM.Api.Repositories;
using RM.Api.ViewModel;

namespace RM.Api.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<List<CharacterViewModel>> GetCharactersAsync()
        {
            try
            {
                List<CharacterViewModel> charactersVw = new List<CharacterViewModel>();

                if (_cache.TryGetValue("GetCharactersAsync", out List<CharacterViewModel> cached)) return cached;

                var characters = await _characterRepository.GetAllAsync();

                if (characters == null) return charactersVw;

                foreach (Character character in characters.Results)
                {
                    if (character.Episode.Count <= 1) continue;

                    charactersVw.Add(new CharacterViewModel(
                        character.Id,
                        character.Name,
                        character.Status,
                        character.Species,
                        character.Type,
                        character.Gender,
                        character.Origin,
                        character.Location,
                        character.Image,
                        character.Episode,
                        character.Url,
                        character.Created));
                }

                _cache.Set("GetCharactersAsync", charactersVw, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });

                return charactersVw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
