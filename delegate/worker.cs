using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public delegate void WorkPerformedHandler( int hours ); 
    public class Worker
    {
        public event WorkPerformedHandler Workperformed;
        public event EventHandler WorkPerformedHandler2;
        public Worker()
        {
            Workperformed += WorkPerformed1;
            WorkPerformedHandler2 += WorkPerformed2;
        }

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

            WorkPerformedHandler2?.Invoke(this, EventArgs.Empty);
        }
        public  void WorkPerformed1(int hours)
        {
            Console.WriteLine($" WorkPerformed1 worked {hours} hours!");
        }

        public  void WorkPerformed2(object sender, EventArgs e)
        {
            Console.WriteLine($" WorkPerformed2 {sender.GetType()} worked {e.ToString()} hours!");
        }
    }


}
