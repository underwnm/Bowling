using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProject
{
    public class Frame
    {
        public int maxPins = 10;
        public int firstThrow;
        public int secondThrow;
        public virtual int total { get { return firstThrow + secondThrow; } }
        public bool isStrike { get { return firstThrow == maxPins; } }
        public bool isSpare { get { return !isStrike && total == maxPins; } }
        public Frame(int firstThrow, int secondThrow)
        {
            this.firstThrow = firstThrow;
            this.secondThrow = secondThrow;
        }
    }
}
