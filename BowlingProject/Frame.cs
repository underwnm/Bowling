using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProject
{
    public class Frame
    {
        public int maxScore = 10;
        public int firstThrow { get; set; }
        public int secondThrow { get; set; }
        public virtual int total { get { return firstThrow + secondThrow; } }
        public bool isStrike { get { return firstThrow == maxScore; } }
        public bool isSpare { get { return !isStrike && total == maxScore; } }
        public Frame(int firstThrow, int secondThrow)
        {
            this.firstThrow = firstThrow;
            this.secondThrow = secondThrow;
        }
    }
}
