using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalc.NET
{
    class OperatorLog : Operator
    {
        public OperatorLog()
        {
        }

        public override int OperandCount
        {
            get { return 1; }
        }

        public override double Evaluate()
        {
            return Math.Log(Children[0].Evaluate(), 10);
        }

        public override string ToString()
        {
            return "log(" + Children[0].ToString() + ")";
        }
    }
}
