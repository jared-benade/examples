using System;
using System.Collections.Generic;

namespace AsynchronousProgramming.AsyncAwait.Helpers
{
    public static class CustomLogger
    {
        private static readonly List<string> Exceptions = new();
        
        public static void LogException(Exception ex)
        {
            Exceptions.Add(ex.Message);
        }

        public static List<string> GetLogs()
        {
            return Exceptions;
        }
    }
}