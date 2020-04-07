using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2020_04_072kL_Events_
{
    class Processor
    {
        private int donePercent = 0;

        public delegate void Progress(int value);

        public delegate void Finish(bool result, int resultValue);

        public event Progress EventProgress;
        public event Finish EventFinish;
        
        private void Work()
        {
            donePercent = 0;
            while (donePercent < 100)
            {
                Thread.Sleep(1000);
                donePercent += 10;
                EventProgress?.Invoke(donePercent);
            }
            Random r = new Random();
            bool b = r.Next(100) % 2 == 0;
            int res = r.Next(2000, 3000);
            EventFinish?.Invoke(b, res);
        }

        public void Start()
        {
            new Thread(new ThreadStart(Work)).Start();
        }
    }
}
