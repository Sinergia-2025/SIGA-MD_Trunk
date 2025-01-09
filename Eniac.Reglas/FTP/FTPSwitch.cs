using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AppFwk.Generic.Ftp
{
    internal static class FTPSwitch
    {
        internal static TraceSwitch Switch;
        static FTPSwitch()
        {
            Switch = new TraceSwitch("AppFwk.Generic.Ftp", "AppFwk.Generic.Ftp");
        }
    }
}