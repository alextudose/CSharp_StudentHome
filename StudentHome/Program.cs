using System;
using System.Diagnostics;
using StudentHome.Core;

namespace StudentHome
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Trace.Listeners.Add(new TextWriterTraceListener("Logger.log", "FileListener"));
                Trace.Listeners.Add(new ConsoleTraceListener());
                Constants.SetPaths();

                Trace.WriteLine("Creating app context");
                AppContext appContext = new AppContext("AppContext.xml");
                Trace.WriteLine("App context created");
                UserInterface appUI = appContext.GetComponent<UserInterface>("appUI");
                
                appUI.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("The App has encountered an error. Sorry.");
                Trace.WriteLine(e.Message);
                Trace.WriteLine(e.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
