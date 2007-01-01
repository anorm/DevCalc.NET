using System;

namespace DevCalcNET
{
    [SymbolAttribute("round")]
    [OperandCountAttribute(1)]
    class OperatorRound : Operator
	{
		public override double Evaluate()
		{
			return Math.Round(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "round(" + Children[0].ToString() + ")";
		}

        public override string ToMathML()
        {
            return "<mrow><mo>round</mo><mo>(</mo>" + Children[0].ToMathML() + "<mo>)</mo></mrow>";
        }
    }
}
