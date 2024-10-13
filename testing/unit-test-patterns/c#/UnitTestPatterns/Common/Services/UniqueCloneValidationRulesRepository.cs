using System.Collections.Generic;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Common.Services
{
    public class UniqueCloneValidationRulesRepository : IUniqueCloneValidationRulesRepository
    {
        public IEnumerable<string> GetValidFirstNames(Gender gender)
        {
            // Make call to database and get list
            return new List<string>();
        }

        public IEnumerable<string> GetValidLastNames()
        {
            // Make call to database and get list
            return new List<string>();
        }

        public int GetMaximumNumberOfEyes()
        {
            // Make call to database and get value
            return 0;
        }
    }
}