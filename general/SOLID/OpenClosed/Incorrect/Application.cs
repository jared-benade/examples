using System;
using System.Collections.Generic;
using OpenClosed.Common.Models;
using OpenClosed.Incorrect.Services;

namespace OpenClosed.Incorrect
{
    public class Application
    {
        public void Run()
        {
            var monitors = new List<ComputerMonitor>
            {
                new() { Name = "Samsung S345", ScreenType = ScreenType.CurvedScreen, PanelType = PanelType.OLED },
                new() { Name = "Philips P532", ScreenType = ScreenType.WideScreen, PanelType = PanelType.LCD },
                new() { Name = "LG L888", ScreenType = ScreenType.WideScreen, PanelType = PanelType.LED },
                new() { Name = "Samsung S999", ScreenType = ScreenType.WideScreen, PanelType = PanelType.OLED },
                new() { Name = "Dell D2J47", ScreenType = ScreenType.CurvedScreen, PanelType = PanelType.LCD }        
            };
            var filter = new ComputerMonitorFilter();
            var lcdMonitors = filter.FilterByPanelType(monitors, PanelType.LCD);
            var curvedLcdMonitors = filter.FilterByScreenType(lcdMonitors, ScreenType.CurvedScreen);
            
            Console.WriteLine("All Curved LCD monitors");
            foreach (var monitor in curvedLcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Panel Type: {monitor.PanelType}, Screen Type: {monitor.ScreenType}");
            }
        }
    }
}