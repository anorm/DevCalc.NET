using System;

namespace DevCalcNET
{
    [SymbolAttribute("cos")]
    [OperandCountAttribute(1)]
    class OperatorCosinus : Operator
	{
		public override double Evaluate()
		{
			return Math.Cos(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "cos(" + Children[0].ToString() + ")";
		}
	}
}
