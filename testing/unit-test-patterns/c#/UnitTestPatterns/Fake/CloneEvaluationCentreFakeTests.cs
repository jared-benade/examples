using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using UnitTestPatterns.Common;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;
using UnitTestPatterns.Fake.FakeImplementation;

namespace UnitTestPatterns.Fake
{
    [TestFixture]
    public class CloneEvaluationCentreFakeTests
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
                    var clone = CreateClone("Bob");
                    var validationRulesRepository = new FakeUniqueCloneValidationRulesRepository();

                    var sut = CreateSut(validationRulesRepository);
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
                    var validationRulesRepository = new FakeUniqueCloneValidationRulesRepository();

                    var sut = CreateSut(validationRulesRepository);
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
                    var clone = CreateClone(lastName: "Stark");
                    var validationRulesRepository = new FakeUniqueCloneValidationRulesRepository();

                    var sut = CreateSut(validationRulesRepository);
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
                    var validationRulesRepository = new FakeUniqueCloneValidationRulesRepository();

                    var sut = CreateSut(validationRulesRepository);
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
                    var clone = CreateClone("Jimmy", "Jones", Gender.Male, 2);
                    var validationRulesRepository = new FakeUniqueCloneValidationRulesRepository();

                    var sut = CreateSut(validationRulesRepository);
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
            
            private static CloneEvaluationCentre CreateSut(IUniqueCloneValidationRulesRepository validationRulesRepository)
            {
                return new CloneEvaluationCentre(validationRulesRepository);
            }
        }
    }
}