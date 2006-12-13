using System;

namespace DevCalcNET
{
    [SymbolAttribute("tan")]
    [OperandCountAttribute(1)]
    class OperatorTangens : Operator
	{
		public override double Evaluate()
		{
			return Math.Tan(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "tan(" + Children[0].ToString() + ")";
		}
	}
}
