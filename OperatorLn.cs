using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalc.NET
{
    class OperatorLn : Operator
    {
        public OperatorLn()
        {
        }

        public override int OperandCount
        {
            get { return 1; }
        }

        public override double Evaluate()
        {
            return Math.Log(Children[0].Evaluate());
        }

        public override string ToString()
        {
            return "ln(" + Children[0].ToString() + ")";
        }
    }
}
