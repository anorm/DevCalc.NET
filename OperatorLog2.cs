using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalc.NET
{
    class OperatorLog2 : Operator
    {
        public OperatorLog2()
        {
        }

        public override int OperandCount
        {
            get { return 1; }
        }

        public override double Evaluate()
        {
            return Math.Log(Children[0].Evaluate(), 2);
        }

        public override string ToString()
        {
            return "log2(" + Children[0].ToString() + ")";
        }
    }
}
