using System;

namespace DevCalcNET
{
    [SymbolAttribute("ceiling")]
    [OperandCountAttribute(1)]
    class OperatorCeiling : Operator
	{
		public override double Evaluate()
		{
			return Math.Ceiling(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "ceiling(" + Children[0].ToString() + ")";
		}
	}
}
