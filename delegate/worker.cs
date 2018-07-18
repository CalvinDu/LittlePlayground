using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public delegate void WorkPerformedHandler( int hours ); 
    public class worker
    {
        public event WorkPerformedHandler Workperformed;
        public virtual void DoWork(int hours)
        {
            OnWorkPerformed(hours);
        }

        protected virtual void OnWorkPerformed( int hours )
        {
            WorkPerformedHandler del = Workperformed as WorkPerformedHandler;
            if (del != null)
            {
                del(hours);
            }
        }
        static void WorkPerformed1(int hours)
        {
            Console.WriteLine($" WorkPerformed1 did {hours} hours!");
        }

        static void WorkPerformed2(int hours)
        {
            Console.WriteLine($" WorkPerformed2 did {hours} hours!");
        }
    }


}
