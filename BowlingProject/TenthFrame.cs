using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProject
{
    public class TenthFrame : Frame
    {
        public int thirdThrow { get; private set; }
        public override int total { get { return base.firstThrow + base.secondThrow + thirdThrow; } }
        public TenthFrame(int firstThrow, int secondThrow, int thirdThrow) : base(firstThrow, secondThrow)
        {
            this.thirdThrow = thirdThrow;
        }
    }
}
