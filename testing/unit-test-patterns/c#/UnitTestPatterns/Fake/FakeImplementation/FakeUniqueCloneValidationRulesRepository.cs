using System.Collections.Generic;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Fake.FakeImplementation
{
    public class FakeUniqueCloneValidationRulesRepository : IUniqueCloneValidationRulesRepository
    {
        private readonly string[] _validMaleFirstNames = {"John", "Jimmy", "Albert", "Tony"};
        private readonly string[] _validFemaleFirstNames = {"Jane", "Rebecca", "Ashley", "Emma"};
        private readonly string[] _validLastNames = {"Smith", "Anderson", "Doe", "Jones"};
        private const int MaxNumberOfEyes = 2;

        public IEnumerable<string> GetValidFirstNames(Gender gender)
        {
            return gender == Gender.Female ? _validFemaleFirstNames : _validMaleFirstNames;
        }

        public IEnumerable<string> GetValidLastNames()
        {
            return _validLastNames;
        }

        public int GetMaximumNumberOfEyes()
        {
            return MaxNumberOfEyes;
        }
    }
}