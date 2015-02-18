using MvcMusicStore.Domain.Entities.Specifications.AlbumSpecs;
using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Entities.Validations
{
    public class AlbumIsValidValidation : Validation<Album>
    {
        public AlbumIsValidValidation()
        {
            base.AddRule(new ValidationRule<Album>(new AlbumTitleIsRequiredSpec(), ValidationMessages.TitleIsRequired));
            base.AddRule(new ValidationRule<Album>(new AlbumPriceIsRequiredSpec(), ValidationMessages.PriceIsRequired));
            base.AddRule(new ValidationRule<Album>(new AlbumPriceMustBeLowerThan100Spec(),ValidationMessages.PriceMustBeBetween001And100));
            base.AddRule(new ValidationRule<Album>(new AlbumTitleLenthMustBeLowerThan160Spec(), ValidationMessages.AlbumTitleLenthMustBeLowerThan160));
            base.AddRule(new ValidationRule<Album>(new AlbumArtUrlLenthMustBeLowerThan1024Spec(), ValidationMessages.AlbumArtUrlLengthMustBeLowerThan1024));
        }
    }
}
