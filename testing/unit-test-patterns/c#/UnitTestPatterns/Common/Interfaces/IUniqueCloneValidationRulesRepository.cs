using System.Collections.Generic;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Common.Interfaces
{
    public interface IUniqueCloneValidationRulesRepository
    {
        IEnumerable<string> GetValidFirstNames(Gender gender);
        IEnumerable<string> GetValidLastNames();
        int GetMaximumNumberOfEyes();
    }
}