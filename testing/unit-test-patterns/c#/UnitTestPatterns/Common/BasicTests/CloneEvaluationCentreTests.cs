using FluentAssertions;
using NUnit.Framework;
using UnitTestPatterns.Common.Services;
using UnitTestPatterns.TestDataBuilder.Builders;

namespace UnitTestPatterns.Common.BasicTests
{
    [TestFixture]
    public class CloneEvaluationCentreTests
    {
        [TestFixture]
        public class IsCloneValid
        {
            [TestFixture]
            public class CloneIsGeneric
            {
                [Test]
                public void GivenCloneIsGenericMale_ShouldReturnValidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder().BuildGenericMale();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepository();

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeTrue();
                }

                [Test]
                public void GivenCloneIsGenericFemale_ShouldReturnValidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder().BuildGenericFemale();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepository();

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeTrue();
                }
            }
        }
    }
}