using NSubstitute;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.TestDataBuilder.Builders
{
    public class UniqueCloneValidationRulesRepositoryTestDataBuilder
    {
        private readonly IUniqueCloneValidationRulesRepository _repository;

        public UniqueCloneValidationRulesRepositoryTestDataBuilder()
        {
            _repository = Substitute.For<IUniqueCloneValidationRulesRepository>();
            _repository.GetMaximumNumberOfEyes().Returns(2);
        }

        public IUniqueCloneValidationRulesRepository Build()
        {
            return _repository;
        }

        public UniqueCloneValidationRulesRepositoryTestDataBuilder WithValidFirstNamesForGender(Gender gender,
            params string[] validFirstNames)
        {
            _repository.GetValidFirstNames(gender).Returns(validFirstNames);
            return this;
        }

        public UniqueCloneValidationRulesRepositoryTestDataBuilder WithValidLastnames(
            params string[] validLastNames)
        {
            _repository.GetValidLastNames().Returns(validLastNames);
            return this;
        }
    }
}