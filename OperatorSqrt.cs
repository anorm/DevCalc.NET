using System;

namespace DevCalc.NET
{
	public class OperatorSqrt : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 1;
			}
		}

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
