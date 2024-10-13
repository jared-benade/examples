using System.Runtime.InteropServices;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnitTestPatterns.Common;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Spy
{
    [TestFixture]
    public class CloneEvaluationCentreSpyTests
    {
        [TestFixture]
        public class IsCloneValid
        {
            [TestFixture]
            public class CloneIsUnique
            {
                [TestCase(Gender.Male)]
                [TestCase(Gender.Female)]
                public void GivenCloneCreatedWithGender_ShouldGetValidFirstNamesForThatGender(Gender cloneGender)
                {
                    // Arrange
                    var clone = CreateClone(gender: cloneGender);
                    var genderParam = new Gender();
                    var validationRulesRepository = Substitute.For<IUniqueCloneValidationRulesRepository>();
                    validationRulesRepository
                        .When(x => x.GetValidFirstNames(Arg.Any<Gender>()))
                        .Do(x =>
                        {
                            var genderArg = x.Arg<Gender>();
                            genderParam = genderArg;
                        });

                    var sut = new CloneEvaluationCentre(validationRulesRepository);
                    // Act
                    sut.IsCloneValid(clone);
                    // Assert
                    genderParam.Should().Be(cloneGender);
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