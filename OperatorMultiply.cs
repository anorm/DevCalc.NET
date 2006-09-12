using System;

namespace DevCalc.NET
{
	public class OperatorMultiply : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 2;
			}
		}

		public OperatorMultiply() : base()
		{
		}

		public override double Evaluate()
		{
			return Children[0].Evaluate() * Children[1].Evaluate();
		}

		public override string ToString()
		{
			return "(" + Children[0].ToString() + " * " + Children[1].ToString() + ")";
		}
	}
}
