using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmileFace
{
    public class StateInfo
    {
        public StateInfo(int totalSpan)
        {
            this.totalSpan = totalSpan;
        }
        public void Start()
        {
            isStart = true;
        }
        public void Step()
        {
            if (isStart)
            {
                if (currSpan <= totalSpan) currSpan++;
            }
        }

        public bool checkStep(int step)
        {
            if (!isStart) return false;
            return step == this.currSpan ? true : false;
        }


        public bool getEnd()
        {
            if (isStart)
            {
                if (currSpan == totalSpan)
                {
                    isStart = false;
                    currSpan = 0;
                    return true;
                }
            }
            return false;
        }
        public bool isStart = false;
        public int totalSpan ;
        public int currSpan = 0;
    }
}
