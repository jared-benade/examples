using OpenClosed.Common.Models;
using OpenClosed.Correct.Interfaces;

namespace OpenClosed.Correct.Helpers
{
    public class PanelTypeSpecification : ISpecification
    {
        private readonly PanelType _panelType;
        
        public PanelTypeSpecification(PanelType panelType)
        {
            _panelType = panelType;
        }
        
        public bool IsSatisfied(ComputerMonitor monitor) => monitor.PanelType == _panelType;
    }
}