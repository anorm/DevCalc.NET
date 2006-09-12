using System;

namespace DevCalc.NET
{
	public class OperatorSinus : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 1;
			}
		}

		public OperatorSinus()
		{
		}

		public override double Evaluate()
		{
			return Math.Sin(Children[0].Evaluate());
		}

		public override string ToString()
		{
			return "sin(" + Children[0].ToString() + ")";
		}
	}
}
