using System;
using System.IO;
using SingleResponsibility.Correct.Interfaces;

namespace SingleResponsibility.Correct.Services
{
    public class Logger : ILogger
    {
        private const string ErrorLogPath = "C:\\Logs\\ErrorLog.txt";
        private const string InfoLogPath = "C:\\Logs\\InfoLog.txt";

        public void Info(string info)
        {
            File.WriteAllText(InfoLogPath, info);
        }

        public void Error(Exception ex)
        {
            File.WriteAllText(ErrorLogPath, ex.Message);
        }
    }
}