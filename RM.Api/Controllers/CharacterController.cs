using Microsoft.AspNetCore.Mvc;
using RM.Api.Services;

namespace RM.Api.Controllers
{
    [Route("api/v1/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        /// <summary>
        /// Returns all the resources.
        /// </summary>
        /// <remarks>Returns all the resources that match with the following filters: Species: Aliens, Status: Unknown and appearing in more than one episode.</remarks>
        /// <param name="request"></param>

        [HttpGet]
        [Route("/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCharactersAsync()
        {
            try
            {
                var result = await _characterService.GetCharactersAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem($"There was a probleam trying to retrieve the data: {ex.Message}");
            }
        }
    }
}
