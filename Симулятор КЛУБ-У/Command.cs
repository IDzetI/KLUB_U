using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_КЛУБ_У
{
    class Command
    {
        Queue<byte> queue;

        public Command()
        {
            queue = new Queue<byte>();
        }

        public void AddSimvol(byte symvol)
        {
            queue.Enqueue(symvol);
        }

        public void Reset()
        {
            queue = new Queue<byte>();
        }

        public int getCommand()
        {
            int command = 0;
            while(queue.Count != 0)
            {
                command += queue.Dequeue() * (int)Math.Pow(10,queue.Count);
            }
            return command;
        }
    }
}
