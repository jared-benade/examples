using System.Runtime.InteropServices;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnitTestPatterns.Common;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Stub
{
    [TestFixture]
    public class CloneEvaluationCentreStubTests
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
                    var clone = CreateClone("Jimmy");
                    var validationRulesRepository = Substitute.For<IUniqueCloneValidationRulesRepository>();
                    validationRulesRepository.GetValidFirstNames(clone.Gender).Returns(new[] {"Not Jimmy"});

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
                    var clone = CreateClone("Ashley", gender: Gender.Male);
                    var validationRulesRepository = Substitute.For<IUniqueCloneValidationRulesRepository>();
                    validationRulesRepository.GetValidFirstNames(Gender.Female).Returns(new[] {"Ashley"});
                    validationRulesRepository.GetValidFirstNames(Gender.Male).Returns(new[] {"Not Ashley"});

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
                    var clone = CreateClone(lastName: "Jones");
                    var validationRulesRepository = Substitute.For<IUniqueCloneValidationRulesRepository>();
                    validationRulesRepository.GetValidFirstNames(clone.Gender).Returns(new[] {clone.FirstName});
                    validationRulesRepository.GetValidLastNames().Returns(new[] {"Not Jones"});

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
                    var clone = CreateClone(numberOfEyes: 3);
                    var validationRulesRepository = Substitute.For<IUniqueCloneValidationRulesRepository>();
                    validationRulesRepository.GetValidFirstNames(clone.Gender).Returns(new[] {clone.FirstName});
                    validationRulesRepository.GetValidLastNames().Returns(new[] {clone.LastName});
                    validationRulesRepository.GetMaximumNumberOfEyes().Returns(2);

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
                    var clone = CreateClone("Jimmy", "Jones", Gender.Male, 2);;
                    var validationRulesRepository = Substitute.For<IUniqueCloneValidationRulesRepository>();
                    validationRulesRepository.GetValidFirstNames(clone.Gender).Returns(new[] {clone.FirstName});
                    validationRulesRepository.GetValidLastNames().Returns(new[] {clone.LastName});
                    validationRulesRepository.GetMaximumNumberOfEyes().Returns(clone.NumberOfEyes);

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    var result = sut.IsCloneValid(clone);
                    // Assert
                    result.IsValid.Should().BeTrue();
                }
            }

            private static IClone CreateClone([Optional] string firstName, [Optional] string lastName,
                [Optional] Gender? gender, [Optional] int? numberOfEyes)
            {
                return new Clone(firstName ?? "John", lastName ?? "Smith", gender ?? Gender.Male, "Black",
                    numberOfEyes ?? 2);
            }
        }
    }
}