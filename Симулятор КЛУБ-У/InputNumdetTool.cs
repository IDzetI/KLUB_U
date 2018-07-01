using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_КЛУБ_У
{
    class InputNumderTool
    {
        private Queue<byte> queue;
        private int number;

        public InputNumderTool()
        {
            queue = new Queue<byte>();
            number = 0;
        }

        public void AddSimvol(byte symvol)
        {
            queue.Enqueue(symvol);
        }

        public void Reset()
        {
            queue = new Queue<byte>();
            number = 0;
        }

        public int GetNumber()
        {
            number *= (int)Math.Pow(10, queue.Count);
            while (queue.Count != 0)
            {
                number += queue.Dequeue() * (int)Math.Pow(10,queue.Count);
            }
            return number;
        }
        
        public bool HasNumber()
        {
            return queue.Count > 0 || number != 0;
        }
    }
}
