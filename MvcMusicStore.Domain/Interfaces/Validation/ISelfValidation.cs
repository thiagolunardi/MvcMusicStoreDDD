using MvcMusicStore.Domain.Validation;

namespace MvcMusicStore.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}