using System;

namespace SingleResponsibility.Correct.Interfaces
{
    public interface ILogger
    {
        void Info(string info);
        void Error(Exception ex);
    }
}