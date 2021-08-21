using System;
using System.Configuration;
using System.IO;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }

    public class TextFileExceptionLogger : IExceptionLogger
    {
        private readonly string _filename;

        public TextFileExceptionLogger(string filename)
        {
            _filename = filename;
        }

        public void Log(Exception ex)
        {
            DateTime now = DateTime.Now;

            using (TextWriter tw = new StreamWriter(_filename, true))
            {
                tw.WriteLine($"[{now}]: [{ex.GetType().Name}] - {ex.Message}\n{ex.StackTrace}");
            }
        }
    }

    public static class AppTextFileLoggerSource
    {
        private static volatile TextFileExceptionLogger _instance;
        private static readonly object _lock = new object();

        public static TextFileExceptionLogger GetInstance()
        {
            if(_instance == null )
            {
                string filepath = Path.Combine(
                                ConfigurationManager.AppSettings["ExceptionLogsDirectory"],
                                DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

                lock (_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new TextFileExceptionLogger(filepath);
                    }
                }
            }

            return _instance;
        }
    }
}
