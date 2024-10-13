using UnitTestPatterns.Common.Models;

namespace UnitTestPatterns.Common.Interfaces
{
    public interface IClone
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Gender Gender { get; }
        public string HairColor { get; }
        public int NumberOfEyes { get; }
    }
}