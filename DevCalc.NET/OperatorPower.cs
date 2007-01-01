using System;

namespace DevCalcNET
{
    [SymbolAttribute("^")]
    [OperandCountAttribute(2)]
    class OperatorPower : Operator
	{
		public override double Evaluate()
		{
			return Math.Pow(Children[0].Evaluate(), Children[1].Evaluate());
		}

		public override string ToString()
		{
			return "(" + Children[0].ToString() + " ^ " + Children[1].ToString() + ")";
		}

        public override string ToMathML()
        {
            return "<apply><power/>" + Children[0].ToMathML() + Children[1].ToMathML() + "</apply>";
        }
	}
}
