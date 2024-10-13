using System.Collections.Generic;
using System.Linq;
using OpenClosed.Common.Models;

namespace OpenClosed.Incorrect.Services
{
    public class ComputerMonitorFilter
    {
        public IEnumerable<ComputerMonitor> FilterByPanelType(IEnumerable<ComputerMonitor> monitors, PanelType type)
        {
            return  monitors.Where(m => m.PanelType == type).ToList();
        }
        
        public IEnumerable<ComputerMonitor> FilterByScreenType(IEnumerable<ComputerMonitor> monitors, ScreenType screenType)
        {
            return monitors.Where(m => m.ScreenType == screenType).ToList();
        }
    }
}