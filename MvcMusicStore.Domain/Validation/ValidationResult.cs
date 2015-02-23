using System.Collections.Generic;
using System.Linq;

namespace MvcMusicStore.Domain.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _erros;
        private string Message { get; set; }
        public bool IsValid { get { return !_erros.Any(); } }
        public IEnumerable<ValidationError> Errors { get { return _erros; } }

        public ValidationResult()
        {
            _erros = new List<ValidationError>();
        }

        public ValidationResult Add(string errorMessage)
        {
            _erros.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _erros.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _erros.AddRange(result.Errors);

            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (_erros.Contains(error))
                _erros.Remove(error);
            return this;
        }
    }

}
