using System;
using System.Diagnostics;

namespace Shiminy
{
    static class Shim
    {
        /// <summary>
        /// A small shim application that expects a command prompt filename as the first argument
        /// proceeded by an optional set of additional arguments to be used when calling the
        /// command prompt application
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var process = new Process
                {
                    StartInfo =
                        {
                            CreateNoWindow = true,
                            UseShellExecute = false, 
                            FileName = args[0]
                        }
                };


            if (args.Length > 1)
            {
                args[0] = string.Empty;
                process.StartInfo.Arguments = string.Join(" ", args);
            }

            process.Start();
        }
    }
}
