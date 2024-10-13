using NSubstitute;
using UnitTestPatterns.Common.Interfaces;
using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.TestDataBuilder.Builders
{
    public class CloneTestDataBuilder
    {
        private readonly IClone _clone;

        public CloneTestDataBuilder()
        {
            _clone = Substitute.For<IClone>();
        }

        public IClone Build()
        {
            return _clone;
        }

        public CloneTestDataBuilder WithFirstName(string firstName)
        {
            _clone.FirstName.Returns(firstName);
            return this;
        }

        public CloneTestDataBuilder WithLastName(string lastName)
        {
            _clone.LastName.Returns(lastName);
            return this;
        }

        private CloneTestDataBuilder WithGender(Gender gender)
        {
            _clone.Gender.Returns(gender);
            return this;
        }

        private CloneTestDataBuilder WithHairColor(string hairColor)
        {
            _clone.HairColor.Returns(hairColor);
            return this;
        }

        public CloneTestDataBuilder WithStandardNumberOfEyes()
        {
            _clone.NumberOfEyes.Returns(2);
            return this;
        }

        public CloneTestDataBuilder IsTriclops()
        {
            _clone.NumberOfEyes.Returns(3);
            return this;
        }

        public CloneTestDataBuilder WithGenericMaleBase()
        {
            return WithFirstName("John")
                .WithLastName("Smith")
                .WithGender(Gender.Male)
                .WithHairColor("Black")
                .WithStandardNumberOfEyes();
        }

        public IClone BuildGenericMale()
        {
            return WithGenericMaleBase()
                .Build();
        }

        public IClone BuildGenericFemale()
        {
            return WithFirstName("Jane")
                .WithLastName("Doe")
                .WithGender(Gender.Female)
                .WithHairColor("Blonde")
                .WithStandardNumberOfEyes()
                .Build();
        }
    }
}