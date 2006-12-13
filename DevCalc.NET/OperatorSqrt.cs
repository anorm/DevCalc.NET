using System;

namespace DevCalcNET
{
    [SymbolAttribute("sqrt")]
    [OperandCountAttribute(1)]
    class OperatorSqrt : Operator
	{
		public OperatorSqrt()
		{
		}

		public override double Evaluate()
		{
			return Math.Sqrt(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "sqrt(" + Children[0].ToString() + ")";
		}
	}
}
