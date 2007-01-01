using System;

namespace DevCalcNET
{
    [SymbolAttribute("pi")]
    [OperandCountAttribute(0)]
	class OperatorPI : Operator
	{
        public OperatorPI()
		{
		}

		public override double Evaluate()
		{
			return Math.PI;
		}

		public override string ToString()
		{
			return "PI";
		}

        public override string ToMathML()
        {
 	        return "<mi>&pi;</mi>";
        }
	}
}
