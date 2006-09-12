using System;

namespace DevCalc.NET
{
	public class OperatorPI : Operator
	{
		public override int OperandCount
		{
			get
			{
				return 0;
			}
		}

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
	}
}
