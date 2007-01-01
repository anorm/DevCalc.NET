using System;
using System.Collections.Generic;
using System.Text;

namespace DevCalcNET
{
    [SymbolAttribute("log")]
    [OperandCountAttribute(1)]
    class OperatorLog : Operator
    {
        public override double Evaluate()
        {
            return Math.Log(Children[0].Evaluate(), 10);
        }

        public override string ToString()
        {
            return "log(" + Children[0].ToString() + ")";
        }

        public override string ToMathML()
        {
            return "<mrow><mo>log</mo><mo>(</mo>" + Children[0].ToMathML() + "<mo>)</mo></mrow>";
        }
    }
}
