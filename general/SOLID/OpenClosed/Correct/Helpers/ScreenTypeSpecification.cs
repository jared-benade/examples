using OpenClosed.Common.Models;
using OpenClosed.Correct.Interfaces;

namespace OpenClosed.Correct.Helpers
{
    public class ScreenTypeSpecification: ISpecification
    {
        private readonly ScreenType _screenType;
        
        public ScreenTypeSpecification(ScreenType screenType)
        {
            _screenType = screenType;
        }

        public bool IsSatisfied(ComputerMonitor monitor) => monitor.ScreenType == _screenType;
    }
}