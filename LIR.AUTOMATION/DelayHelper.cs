using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LIR.AUTOMATION
{
    internal static class DelayHelper
    {
        /// <summary>
        /// Delay browser interaction for better demo/presentation
        /// </summary>
        /// <param name="secontsToPause"></param>
        public static void Pause(int secontsToPause = 1000)
        {
            Thread.Sleep(secontsToPause);
        }
    }
}
