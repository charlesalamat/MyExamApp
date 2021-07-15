using System;
using System.Threading;

namespace SeleniumAutomation
{
    public class DelayHelper
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
