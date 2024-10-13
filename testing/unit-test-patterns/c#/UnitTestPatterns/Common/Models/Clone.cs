using UnitTestPatterns.Common.Interfaces;

namespace UnitTestPatterns.Common.Models
{
    public class Clone : IClone
    {
        public Clone(string firstName, string lastName, Gender gender, string hairColor, int numberOfEyes)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            HairColor = hairColor;
            NumberOfEyes = numberOfEyes;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public Gender Gender { get; }
        public string HairColor { get; }
        public int NumberOfEyes { get; }
    }
}