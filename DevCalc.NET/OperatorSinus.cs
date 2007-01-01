using System;

namespace DevCalcNET
{
    [SymbolAttribute("sin")]
    [OperandCountAttribute(1)]
    class OperatorSinus : Operator
	{
		public override double Evaluate()
		{
			return Math.Sin(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "sin(" + Children[0].ToString() + ")";
		}

        public override string ToMathML()
        {
            return "<apply><sin/>" + Children[0].ToMathML() + "</apply>";
        }
	}
}
