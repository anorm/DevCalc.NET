using System;

namespace DevCalcNET
{
    [SymbolAttribute("floor")]
    [OperandCountAttribute(1)]
    class OperatorFloor : Operator
	{
		public override double Evaluate()
		{
			return Math.Floor(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "floor(" + Children[0].ToString() + ")";
		}
	}
}
