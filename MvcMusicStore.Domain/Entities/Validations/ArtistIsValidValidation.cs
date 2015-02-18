using MvcMusicStore.Domain.Entities.Specifications.ArtistSpecs;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities.Validations
{
    public class ArtistIsValidValidation : Validation<Artist>
    {
        public ArtistIsValidValidation()
        {
            base.AddRule(new ValidationRule<Artist>(new ArtistNameIsRequiredSpec(), ValidationMessages.NameIsRequired));
        }
    }
}
