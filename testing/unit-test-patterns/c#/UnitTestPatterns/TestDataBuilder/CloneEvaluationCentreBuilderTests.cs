using FluentAssertions;
using NUnit.Framework;
using UnitTestPatterns.Common;
using UnitTestPatterns.Common.Models;
using UnitTestPatterns.TestDataBuilder.Builders;

namespace UnitTestPatterns.TestDataBuilder
{
    [TestFixture]
    public class CloneEvaluationCentreBuilderTests
    {
        [TestFixture]
        public class IsCloneValid
        {
            [TestFixture]
            public class CloneIsUnique
            {
                [Test]
                public void GivenCloneWithInvalidFirstName_ShouldReturnInvalidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder()
                        .WithGenericMaleBase()
                        .WithFirstName("Jimmy")
                        .Build();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepositoryTestDataBuilder()
                        .WithValidFirstNamesForGender(clone.Gender, "Not Jimmy")
                        .WithValidLastnames(clone.LastName)
                        .Build();

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeFalse();
                    result.Message.Should().Be("Clone has invalid first name");
                }            
                
                [Test]
                public void GivenCloneWithInvalidFirstNameForTheirGender_ShouldReturnInvalidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder()
                        .WithGenericMaleBase()
                        .WithFirstName("Ashley")
                        .Build();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepositoryTestDataBuilder()
                        .WithValidFirstNamesForGender(Gender.Female, "Ashley")
                        .WithValidFirstNamesForGender(Gender.Male, "Not Ashley")
                        .WithValidLastnames(clone.LastName)
                        .Build();

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeFalse();
                    result.Message.Should().Be("Clone has invalid first name");
                }

                [Test]
                public void GivenCloneWithInvalidLastName_ShouldReturnInvalidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder()
                        .WithGenericMaleBase()
                        .WithLastName("Jones")
                        .Build();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepositoryTestDataBuilder()
                        .WithValidFirstNamesForGender(clone.Gender, clone.FirstName)
                        .WithValidLastnames("Not Jones")
                        .Build();

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeFalse();
                    result.Message.Should().Be("Clone has invalid last name");
                }

                [Test]
                public void GivenCloneWithTooManyEyes_ShouldReturnInvalidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder()
                        .WithGenericMaleBase()
                        .IsTriclops()
                        .Build();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepositoryTestDataBuilder()
                        .WithValidFirstNamesForGender(clone.Gender, clone.FirstName)
                        .WithValidLastnames(clone.LastName)
                        .Build();

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeFalse();
                    result.Message.Should().Be("Clone has too many eyes");
                }

                [Test]
                public void GivenCloneHasValidFirstName_AndValidLastName_AndValidNumberOfEyes_ShouldReturnValidValidationResponse()
                {
                    // Arrange
                    var clone = new CloneTestDataBuilder()
                        .WithGenericMaleBase()
                        .WithFirstName("Jimmy")
                        .WithLastName("Jones")
                        .WithStandardNumberOfEyes()
                        .Build();
                    var validationRulesRepository = new UniqueCloneValidationRulesRepositoryTestDataBuilder()
                        .WithValidFirstNamesForGender(clone.Gender, clone.FirstName)
                        .WithValidLastnames(clone.LastName)
                        .Build();

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