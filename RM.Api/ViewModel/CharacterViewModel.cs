using RM.Api.ValueObjects;

namespace RM.Api.ViewModel
{
    public sealed record CharacterViewModel (
            int Id,
            string Name,
            string Status,
            string Species,
            string Type,
            string Gender,
            Origin? Origin,
            Location? Location,
            string Image,
            List<string> Episode,
            string Url,
            string Created);
}
