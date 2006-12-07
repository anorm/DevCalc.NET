using System;

namespace DevCalcNET
{
    [SymbolAttribute("/")]
    [OperandCountAttribute(2)]
    class OperatorDivide : Operator
	{
        public OperatorDivide()
		{
		}

		public override double Evaluate()
		{
			return Children[0].Evaluate() / Children[1].Evaluate();
		}

		public override string ToString()
		{
			return "(" + Children[0].ToString() + " / " + Children[1].ToString() + ")";
		}


	}
}
