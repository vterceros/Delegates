using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Callback
{
    public class Process
    {
        public delegate void Progress(int percent);
        public void RunBigProcess(Progress progress)
        {
            int total = 500000;
            int percent10 = 50000;
            for (int i = 1; i <= total; i++)
            {
                if (i % percent10 == 0)
                {
                    progress(i*100/total);
                }
            }            
        }
    }
}
