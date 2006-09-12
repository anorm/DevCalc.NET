using System;

namespace DevCalc.NET
{
	public class OperatorPlus : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 2;
			}
		}

		public OperatorPlus()
		{
		}

		public override double Evaluate()
		{
			return Children[0].Evaluate() + Children[1].Evaluate();
		}

		public override string ToString()
		{
			return "(" + Children[0].ToString() + " + " + Children[1].ToString() + ")";
		}
	}
}
