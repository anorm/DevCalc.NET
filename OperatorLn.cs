using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalcNET
{
    [SymbolAttribute("ln")]
    [OperandCountAttribute(1)]
    class OperatorLn : Operator
    {
        public OperatorLn()
        {
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
