using System;
using System.Linq;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Common
{
    public class CloneEvaluationCentre
    {
        private readonly IUniqueCloneValidationRulesRepository _uniqueCloneValidationRulesRepository;

        public CloneEvaluationCentre(IUniqueCloneValidationRulesRepository uniqueCloneValidationRulesRepository)
        {
            _uniqueCloneValidationRulesRepository = uniqueCloneValidationRulesRepository;
        }

        public ValidationResult IsCloneValid(IClone clone)
        {
            if (IsGenericMale(clone) || IsGenericFemale(clone))
            {
                return ValidationResult.IsValidResult();
            }

            var validFirstNames = _uniqueCloneValidationRulesRepository.GetValidFirstNames(clone.Gender);
            var hasValidFirstName = validFirstNames.Contains(clone.FirstName, StringComparer.InvariantCultureIgnoreCase);
            if (!hasValidFirstName)
            {
                return ValidationResult.IsInvalidResult("Clone has invalid first name");
            }
            
            var validLastNames = _uniqueCloneValidationRulesRepository.GetValidLastNames();
            var hasValidLastName = validLastNames.Contains(clone.LastName, StringComparer.InvariantCultureIgnoreCase);
            if (!hasValidLastName)
            {
                return ValidationResult.IsInvalidResult("Clone has invalid last name");
            }
            
            var maximumNumberOfEyes = _uniqueCloneValidationRulesRepository.GetMaximumNumberOfEyes();
            var hasCorrectNumberOfEyes = clone.NumberOfEyes <= maximumNumberOfEyes;
            if (!hasCorrectNumberOfEyes)
            {
                return ValidationResult.IsInvalidResult("Clone has too many eyes");
            }
            
            return ValidationResult.IsValidResult();
        }

        private static bool IsGenericMale(IClone clone)
        {
            return clone.FirstName == "John" &&
                   clone.LastName == "Smith" &&
                   clone.Gender == Gender.Male &&
                   clone.HairColor == "Black" &&
                   HasStandardNumberOfEyes(clone);
        }

        private static bool IsGenericFemale(IClone clone)
        {
            return clone.FirstName == "Jane" &&
                   clone.LastName == "Doe" &&
                   clone.Gender == Gender.Female &&
                   clone.HairColor == "Blonde" &&
                   HasStandardNumberOfEyes(clone);
        }

        private static bool HasStandardNumberOfEyes(IClone clone)
        {
            return clone.NumberOfEyes == 2;
        }
    }
}