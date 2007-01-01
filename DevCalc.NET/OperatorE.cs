using System;

namespace DevCalcNET
{
    [SymbolAttribute("e")]
    [OperandCountAttribute(0)]
    class OperatorE : Operator
	{
		public override double Evaluate()
		{
			return Math.E;
		}

		public override string ToString()
		{
			return "E";
		}

        public override string ToMathML()
        {
            return "<mi>e</mi>";
        }
    }
}
